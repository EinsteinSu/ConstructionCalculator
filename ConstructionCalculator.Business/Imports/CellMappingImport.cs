using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class CellMappingImport : ExcelDataImportBase
    {
        public CellMappingImport(string fileName) : base(fileName)
        {
        }

        protected override bool IncludeHeader => false;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var cell = new CellMapping();
            cell.ColumnNumber = (int)cells[row, 1].Value;
            cell.ColumnExcelNumber = cells[row, 2].Text;
            cell.ColumnName = cells[row, 3].Text;
            Context.CellMappings.Add(cell);
        }
    }
}
