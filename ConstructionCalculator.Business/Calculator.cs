using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using ConstructionCalculator.Business.Utilities;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ConstructionCalculator.Business
{
    //todo: unit test is very important
    public class Calculator
    {
        public ILogPrint Print { get; set; }

        public IShowProgress ShowProgress { get; set; }

        protected string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;

        private CalculationTemplate _template;
        public string Calc(ConstructionDataContext context, CalculationTemplate template)
        {
            _template = template;
            context.Database.Log = Print.PrintLog;
            var list = context.Constructions.Where(w => w.FileId == template.Construction.Id).ToList();
            var fileName = Path.Combine(BaseDirectory, $"{Guid.NewGuid()}.xlsx");
            var calculatedFileName = Path.Combine(BaseDirectory, $"{Guid.NewGuid()}.xlsx");
            list.Export(fileName, $"{_template.Construction.Name} Calculated");
            using (var excel = new ExcelPackage(new FileInfo(fileName)))
            {
                ProcessInExcel(excel, context);
                excel.SaveAs(new FileInfo(calculatedFileName));
            }

            return calculatedFileName;
        }

        private void ProcessInExcel(ExcelPackage excel, ConstructionDataContext context)
        {
            var cellmappings =
                context.CellMappings.Where(w => w.FileId == _template.CellMapping.Id).ToList();
            var sheet = excel.Workbook.Worksheets[1];
            var row = 2; //with header
            SetHeader(sheet, 1, cellmappings);
            ShowProgress?.SetMaxValue(context.Constructions.Count(c => c.FileId == _template.Construction.Id));

            foreach (var construction in context.Constructions.Where(w => w.FileId == _template.Construction.Id).Include(i => i.BusinessFeature)
                .Include(i => i.ConstructionValue))
            {
                SetFormular(context, sheet, row, cellmappings, construction);
                row++;
                ShowProgress?.SetCurrentValue(row - 2);
            }
            ShowProgress?.Done();
        }

        public void SetHeader(ExcelWorksheet sheet, int row, IList<CellMapping> mappings)
        {
            for (var i = 25; i < mappings.Count; i++)
            {
                var mapping = mappings[i];
                var cell = sheet.Cells[row, mapping.ColumnNumber];
                cell.Value = mapping.ColumnName;
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }
        }

        public void SetFormular(ConstructionDataContext context, ExcelWorksheet sheet, int row,
            IList<CellMapping> mappings, Construction construction)
        {
            //load business value
            //find the column at the end of the raw data e.g 11, 11 is a constant value
            for (var i = 25; i < mappings.Count; i++)
            {
                var mapping = mappings[i];
                var formula = ParameterReplace(mapping.Formula, construction);
                formula = formula.Replace("{row}", row.ToString());
                var cell = sheet.Cells[row, mapping.ColumnNumber];
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                cell.Formula = formula;
                cell.Style.Numberformat.Format = GetDigitalFormat(mapping.Digital);
                Print?.PrintLog($"{mapping.ColumnExcelNumber}:{formula}");
                cell.Calculate();
                Print?.PrintLog($"Calculated, Result:{cell.Value}");
                var value = cell.Value.ToString().ConvertData<double>();
                if (mapping.Group == CalculatGroup.Result) SetResult(context, cell, value);
                if (mapping.Group == CalculatGroup.ParameterT) cell.Value = GetParamerT(value);
            }
        }

        public string GetDigitalFormat(int digital)
        {
            var result = "0.";
            for (var i = 0; i < digital; i++) result += "0";

            return result;
        }

        public double GetParamerT(double value)
        {
            Print?.PrintLog($"Parameter T Value: {value}");
            if (value <= 0 || value >= 0.5)
                return 0.5;
            return value;
        }

        private void SetResult(ConstructionDataContext context, ExcelRange cell, double value)
        {
            Print?.PrintLog($"Value: {value}");
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            var item = GetRiskLevel(context, value);
            if (item != null)
            {
                Print?.PrintLog($"Color: {item.Color}");
                cell.Style.Fill.BackgroundColor.SetColor(item.Color.ConvertToColor());
                cell.Value = item.Description;
            }
            else
            {
                Print?.PrintLog("Warning: Can not found any risk level.");
            }
        }

        public RiskLevel GetRiskLevel(ConstructionDataContext context, double value)
        {
            return context.RiskLevels.FirstOrDefault(w =>
                w.MinValue < value && w.MaxValue >= value && w.FileId == _template.RiskLevel.Id);
        }

        public Color GetRiskLevelColor(double value, ConstructionDataContext context)
        {
            var list = context.RiskLevels.Where(w => w.FileId == _template.RiskLevel.Id).ToList();


            var item =
                context.RiskLevels.FirstOrDefault(w => w.MinValue < value && w.MaxValue >= value
                                                                          && w.FileId == _template.RiskLevel.Id);
            if (item == null)
                return Color.Black;
            return item.Color.ConvertToColor();
        }

        private string Replace(string item, string source, string target)
        {
            Print?.PrintLog($"Replace {source} to {target}");
            return item.Replace(source, target);
        }


        //replace the data from parameter table by construction
        public string ParameterReplace(string formula, Construction construction)
        {
            //business values
            formula = Replace(formula, "GDQI",
                construction.BusinessFeature.GdQi.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "YDQM",
                construction.BusinessFeature.YdQm.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "HZMYYZI",
                construction.BusinessFeature.Hzmyyzi.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "HDYZA",
                construction.BusinessFeature.Hdyza.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "YLYZD",
                construction.BusinessFeature.Ylyzd.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "SSSJXZZP",
                construction.BusinessFeature.Sssjxzzp.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "JZYZ",
                construction.BusinessFeature.Jzyz.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "RKMDQZ",
                construction.BusinessFeature.Rkmdqz.ToString(CultureInfo.InvariantCulture));
            //construction values
            formula = Replace(formula, "JGKHSJ",
                construction.ConstructionValue.Jgkhsj.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "WQKHSJ",
                construction.ConstructionValue.Wqkhsj.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "WDDDKHSJ",
                construction.ConstructionValue.Wdkhsj.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "NQKHSJ",
                construction.ConstructionValue.Nqkhsj.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "JZKHYZF",
                construction.ConstructionValue.Jzkhyz.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "PJKHNLF",
                construction.ConstructionValue.Pjkhnl.ToString(CultureInfo.InvariantCulture));
            formula = Replace(formula, "JGKHYZF0",
                construction.ConstructionValue.Jgkhyz.ToString(CultureInfo.InvariantCulture));
            return formula;
        }
    }
}