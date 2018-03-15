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

        //is it include header
        protected abstract bool IncludeHeader { get; }

        //which worksheet can be import
        protected abstract int SheetNumber { get; }

        protected int GetRowCount()
        {
            var sheet = Excel.Workbook.Worksheets[SheetNumber];
            if (sheet == null)
                return 0;
            int count = 0;
            while (true)
            {
                if (string.IsNullOrEmpty(sheet.Cells[count, 1].Text.Trim()))
                {
                    break;
                }
                count++;
            }

            if (IncludeHeader)
            {
                count = count - 1;
            }
            return count;
        }

        public void Import()
        {
            var count = GetRowCount();
            var cells = Excel.Workbook.Worksheets[SheetNumber].Cells;
            for (int i = 0; i < count; i++)
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
