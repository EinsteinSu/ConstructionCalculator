using System;
using System.IO;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class ConstructionValueImport : ExcelDataImportBase
    {
        public ConstructionValueImport(string fileName) : base(fileName)
        {
        }

        public ConstructionValueImport(Stream file) : base(file)
        {
        }

        protected override bool IncludeHeader => false;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var c = new ConstructionValue();
            c.Name = cells[row, 1].Text;
            c.Id = cells[row, 2].Text.ConvertData<int>();
            c.Jgkhsj = cells[row, 4].Text.ConvertData<double>();
            c.Wqkhsj = cells[row, 5].Text.ConvertData<double>();
            c.Wdkhsj = cells[row, 6].Text.ConvertData<double>();
            c.Nqkhsj = cells[row, 7].Text.ConvertData<double>();
            c.Pjkhnl = cells[row, 8].Text.ConvertData<double>();
            c.Jgkhyz = cells[row, 9].Text.ConvertData<double>();
            c.Jzkhyz = cells[row, 10].Text.ConvertData<double>();
            Enum.TryParse(cells[row, 3].Text.Trim(), out ConstructionDesignRequirement requirement);
            c.DesignRequirement = requirement;
            Context.ConstructionValues.Add(c);
        }
    }
}