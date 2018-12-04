using System;
using System.IO;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using log4net;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public abstract class ExcelDataImportBase : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger("ExcelDataImport");
        public ConstructionDataContext Context { get; set; }
        protected ExcelPackage Excel;
        public ILogPrint Print { get; set; }

        public IShowProgress ShowProgress { get; set; }

        public ExcelDataImportBase(string fileName, string database = "Construction")
        {
            Excel = new ExcelPackage(new FileInfo(fileName));
            Context = new ConstructionDataContext(database);
        }

        public ExcelDataImportBase(Stream stream, string database = "Construction")
        {
            Excel = new ExcelPackage(stream);
            Context = new ConstructionDataContext(database);
        }

        //is it include header
        public bool IncludeHeader { get; set; }

        //which worksheet can be import
        protected abstract int SheetNumber { get; }

        public int RowCount => GetRowCount();

        public virtual bool IgnoreSaveData { get; set; }

        public Action<double> ShowPercentage { get; set; }

        public int FileId { get; set; }


        public void Dispose()
        {
            Excel?.Dispose();
            Context?.Dispose();
        }

        protected int GetRowCount()
        {
            var sheet = Excel.Workbook.Worksheets[SheetNumber];
            if (sheet == null)
                return 0;
            var rowCount = 1;
            while (true)
            {
                if (string.IsNullOrEmpty(sheet.Cells[rowCount, 1].Text.Trim())) break;
                rowCount++;
            }

            return rowCount - 1;
        }

        public void Import()
        {
            var count = RowCount;
            ShowProgress?.SetMaxValue(count);
            var cells = Excel.Workbook.Worksheets[SheetNumber].Cells;
            Print?.PrintLog("Start importing data from excel");
            var startRow = IncludeHeader ? 2 : 1;
            for (var i = startRow; i < count + 1; i++)
            {
                ImportRow(cells, i);
                Print?.PrintLog($"Rows {i} has imported.");
                ShowProgress?.SetCurrentValue(i);
                ShowPercentage?.Invoke((double)i / count * 100.00);
            }

            try
            {
                Print?.PrintLog("Start saving to database.");
                if (!IgnoreSaveData)
                {
                    Context.Database.Log = s =>
                    {
                        Log.Info(s);
                        Print?.PrintLog(s);
                    };

                }
            }
            catch (Exception e)
            {
                var errors = e.Message;
                if (e.InnerException != null)
                    errors += "Internal Exception:\r" + e.InnerException.Message;
                Print?.PrintLog(errors);
                throw new Exception("Could not save data." + errors);
            }
            finally
            {
                ShowProgress?.Done();
            }
        }

        public abstract void ImportRow(ExcelRange cells, int row);
    }
}