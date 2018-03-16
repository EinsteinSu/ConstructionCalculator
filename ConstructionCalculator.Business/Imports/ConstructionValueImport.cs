using System;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class ConstructionValueImport : ExcelDataImportBase
    {
        public ConstructionValueImport(string fileName) : base(fileName)
        {
        }

        protected override bool IncludeHeader => false;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var c = new ConstructionValue();
            c.Name = cells[row, 1].Text;
            c.Id = (int) cells[row, 2].Value;
            Enum.TryParse(cells[row, 3].Text.Trim(), out ConstructionDesignRequirement requirement);
            c.DesignRequirement = requirement;
            c.Jgkhsj = (double) cells[row, 4].Value;
            c.Wqkhsj = (double) cells[row, 5].Value;
            c.Wdkhsj = (double) cells[row, 6].Value;
            c.Nqkhsj = (double) cells[row, 7].Value;
            c.Pjkhnl = (double) cells[row, 8].Value;
            c.Jgkhyz = (double) cells[row, 9].Value;
            c.Jzkhyz = (double) cells[row, 10].Value;
            Context.ConstructionValues.Add(c);
        }
    }
}