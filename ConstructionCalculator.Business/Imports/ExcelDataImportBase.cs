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

        public ExcelDataImportBase(string fileName)
        {
            Excel = new ExcelPackage(new FileInfo(fileName));
            Context = new ConstructionDataContext();
        }

        public ExcelDataImportBase(Stream stream)
        {
            Excel = new ExcelPackage(stream);
            Context = new ConstructionDataContext();
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

            if (IncludeHeader)
            {
                rowCount = rowCount - 2;
            }
            return rowCount - 1;
        }

        public void Import()
        {
            var count = RowCount;
            var cells = Excel.Workbook.Worksheets[SheetNumber].Cells;
            for (int i = 1; i < count + 1; i++)
            {
                ImportRow(cells, i);
                ShowPercentage?.Invoke((double)i / count * 100.00);
            }

            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Could not save data." + e.Message);
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
