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
            IncludeHeader = false;
        }

        public ConstructionValueImport(Stream file) : base(file)
        {
            IncludeHeader = false;
        }


        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var c = new ConstructionValue
            {
                Name = cells[row, 1].Text,
                FileId = FileId,
                Id = cells[row, 2].Text.ConvertData<int>(),
                Jgkhsj = cells[row, 4].Text.ConvertData<double>(),
                Wqkhsj = cells[row, 5].Text.ConvertData<double>(),
                Wdkhsj = cells[row, 6].Text.ConvertData<double>(),
                Nqkhsj = cells[row, 7].Text.ConvertData<double>(),
                Pjkhnl = cells[row, 8].Text.ConvertData<double>(),
                Jgkhyz = cells[row, 9].Text.ConvertData<double>(),
                Jzkhyz = cells[row, 10].Text.ConvertData<double>()
            };
            Enum.TryParse(cells[row, 3].Text.Trim(), out ConstructionDesignRequirement requirement);
            c.DesignRequirement = requirement;
            Context.ConstructionValues.Add(c);
        }
    }
}