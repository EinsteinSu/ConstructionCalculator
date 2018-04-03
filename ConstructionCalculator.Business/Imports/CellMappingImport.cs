using System.IO;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class CellMappingImport : ExcelDataImportBase
    {
        public CellMappingImport(string fileName) : base(fileName)
        {
        }

        public CellMappingImport(Stream file) : base(file)
        {
        }

        protected override bool IncludeHeader => false;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var cell = new CellMapping
            {
                ColumnNumber = cells[row, 1].Text.ConvertData(0),
                ColumnExcelNumber = cells[row, 2].Text,
                ColumnName = cells[row, 3].Text,
                Group = (CalculatGroup)cells[row, 4].Text.ConvertData(0),
                Formula = cells[row, 5].Text,
                Digital = cells[row, 6].Text.ConvertData(2)
            };
            Context.CellMappings.Add(cell);
        }
    }
}