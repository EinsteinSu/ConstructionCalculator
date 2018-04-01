using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using log4net;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ConstructionCalculator.Business
{
    //to be tested using interface for mocking
    public class CalculatorHelper
    {
        private static readonly ILog Log = LogManager.GetLogger("CalculatorHelper");
        public static void CalcAndExportExcel(string fileName)
        {
            string originalFileName = fileName;
            string savingFileName = Path.Combine(Path.GetDirectoryName(fileName),
                Path.GetFileName(fileName).Replace(".xlsx", "") + "_Processed.xlsx");

            var importer = new ConstructionImport(originalFileName);
            importer.Import();

            using (var excel = new ExcelPackage(new FileInfo(originalFileName)))
            {
                ProcessInExcel(excel);
                excel.SaveAs(new FileInfo(savingFileName));
            }
        }

        public static void Calc(Stream stream, Action<ExcelPackage> assertAction)
        {
            var importer = new ConstructionImport(stream);
            importer.Import();

            using (var excel = new ExcelPackage(stream))
            {
                ProcessInExcel(excel);
                assertAction?.Invoke(excel);
            }
        }

        private static void ProcessInExcel(ExcelPackage excel)
        {
            using (var context = new ConstructionDataContext("Construction"))
            {
                var cellmappings = context.CellMappings.ToList();
                var sheet = excel.Workbook.Worksheets[1];
                int row = 2;//with header
                SetHeader(sheet, 1, cellmappings);
                foreach (var construction in context.Constructions.Include(i => i.BusinessFeature).Include(i => i.ConstructionValue))
                {
                    SetFormular(context, sheet, row, cellmappings, construction);
                    row++;
                }
                //sheet.Cells.Calculate();
                //todo process the t column that set the vale to 0.5 which less than 0 or greater than 0.5, otherwise 
                //last 3 columns process
                //for (int i = cellmappings.Count - 3; i < cellmappings.Count; i++)
                //{
                //    Log.Info($"Setting color of {cellmappings[i].ColumnExcelNumber}");
                //    for (int j = 2; j < row; j++)
                //    {
                //        var cell = sheet.Cells[j, i + 1];
                //        var value = cell.Value.ToString().ConvertData<double>();
                //        Log.Info($"Value: {value}");
                //        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                //        var item = GetRiskLevel(value, context);
                //        if (item != null)
                //        {
                //            Log.Info($"Color: {item.Color}");
                //            cell.Style.Fill.BackgroundColor.SetColor(item.Color.ConvertToColor());
                //            cell.Value = item.Description;
                //        }
                //        else
                //        {
                //            Log.Warn("Can not found any risk level.");
                //        }
                //    }
                //}
                context.Database.ExecuteSqlCommand("Delete from Constructions");
            }
        }

        public static void SetHeader(ExcelWorksheet sheet, int row, IList<CellMapping> mappings)
        {
            for (int i = 25; i < mappings.Count; i++)
            {
                var mapping = mappings[i];
                var cell = sheet.Cells[row, mapping.ColumnNumber];
                cell.Value = mapping.ColumnName;
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }
        }

        public static void SetFormular(ConstructionDataContext context, ExcelWorksheet sheet, int row, IList<CellMapping> mappings, Construction construction)
        {
            //load business value
            //find the column at the end of the raw data e.g 11, 11 is a constant value
            for (int i = 25; i < mappings.Count; i++)
            {
                var mapping = mappings[i];
                var formula = ParameterReplace(mapping.Formula, construction);
                formula = formula.Replace("{row}", row.ToString());
                var cell = sheet.Cells[row, mapping.ColumnNumber];
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                cell.Formula = formula;
                cell.Style.Numberformat.Format = "0.00";
                cell.Calculate();
                var value = cell.Value.ToString().ConvertData<double>();
                if (mapping.Group == CalculatGroup.Result)
                {
                    SetResult(cell, value, context);
                }

                if (mapping.Group == CalculatGroup.ParameterT)
                {
                    cell.Value = GetParamerT(value);
                }
                Log.Info($"{mapping.ColumnExcelNumber}:{ formula}");
            }
        }

        public static double GetParamerT(double value)
        {
            Log.InfoFormat($"Parameter T Value: {value}");
            if (value <= 0 || value >= 0.5)
                return 0.5;
            return value;
        }

        private static void SetResult(ExcelRange cell, double value, ConstructionDataContext context)
        {
            Log.Info($"Value: {value}");
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            var item = GetRiskLevel(value, context);
            if (item != null)
            {
                Log.Info($"Color: {item.Color}");
                cell.Style.Fill.BackgroundColor.SetColor(item.Color.ConvertToColor());
                cell.Value = item.Description;
            }
            else
            {
                Log.Warn("Can not found any risk level.");
            }
        }

        public static RiskLevel GetRiskLevel(double value, ConstructionDataContext context)
        {
            return context.RiskLevels.FirstOrDefault(w => w.MinValue < value && w.MaxValue >= value);
        }

        public static Color GetRiskLevelColor(double value, ConstructionDataContext context)
        {
            var item = context.RiskLevels.FirstOrDefault(w => w.MinValue < value && w.MaxValue >= value);
            if (item == null)
                return Color.Black;
            return item.Color.ConvertToColor();
        }


        //replace the data from parameter table by construction
        public static string ParameterReplace(string formula, Construction construction)
        {
            //business values
            formula = formula.Replace("GDQI", construction.BusinessFeature.GdQi.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("YDQM", construction.BusinessFeature.YdQm.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("HZMYYZI", construction.BusinessFeature.Hzmyyzi.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("HDYZA", construction.BusinessFeature.Hdyza.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("YLYZD", construction.BusinessFeature.Ylyzd.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("SSSJXZZP", construction.BusinessFeature.Sssjxzzp.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("JZYZ", construction.BusinessFeature.Jzyz.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("RKMDQZ", construction.BusinessFeature.Rkmdqz.ToString(CultureInfo.InvariantCulture));
            //construction values
            formula = formula.Replace("JGKHSJ", construction.ConstructionValue.Jgkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("WQKHSJ", construction.ConstructionValue.Wqkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("WDDDKHSJ", construction.ConstructionValue.Wdkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("NQKHSJ", construction.ConstructionValue.Nqkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("JZKHYZF", construction.ConstructionValue.Jzkhyz.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("PJKHNLF", construction.ConstructionValue.Pjkhnl.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("JGKHYZF0", construction.ConstructionValue.Jgkhyz.ToString(CultureInfo.InvariantCulture));
            return formula;
        }


    }
}
