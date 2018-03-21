using System.IO;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class BusinessValueImport : ExcelDataImportBase
    {
        public BusinessValueImport(string fileName) : base(fileName)
        {
        }

        public BusinessValueImport(Stream file) : base(file)
        {
        }

        protected override bool IncludeHeader => true;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var b = new BusinessValue
            {
                Id = cells[row, 1].Text.ConvertData<int>(),
                Name = cells[row, 2].Text
            };
            Context.BusinessValues.Add(b);
        }
    }
}