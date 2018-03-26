using System;
using System.IO;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public abstract class ExcelDataImportBase : IDisposable
    {
        protected ExcelPackage Excel;
        protected ConstructionDataContext Context;

        public ExcelDataImportBase(string fileName,string database = "Construction")
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
        protected abstract bool IncludeHeader { get; }

        //which worksheet can be import
        protected abstract int SheetNumber { get; }

        public int RowCount => GetRowCount();

        protected int GetRowCount()
        {
            var sheet = Excel.Workbook.Worksheets[SheetNumber];
            if (sheet == null)
                return 0;
            int rowCount = 1;
            while (true)
            {
                if (string.IsNullOrEmpty(sheet.Cells[rowCount, 1].Text.Trim()))
                {
                    break;
                }
                rowCount++;
            }
            return rowCount - 1;
        }

        protected virtual bool IgnoreSaveData => false;

        public void Import()
        {
            var count = RowCount;
            var cells = Excel.Workbook.Worksheets[SheetNumber].Cells;
            var startRow = IncludeHeader ? 2 : 1;
            for (int i = startRow; i < count + 1; i++)
            {
                ImportRow(cells, i);
                ShowPercentage?.Invoke((double)i / count * 100.00);
            }

            try
            {
                if (!IgnoreSaveData)
                {
                    Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                string errors = e.Message;
                if (e.InnerException != null)
                    errors += "Internal Exception:\r" + e.InnerException.Message;
                throw new Exception("Could not save data." + errors);
            }
        }

        public Action<double> ShowPercentage { get; set; }

        public abstract void ImportRow(ExcelRange cells, int row);


        public void Dispose()
        {
            Excel?.Dispose();
            Context?.Dispose();
        }
    }
}
