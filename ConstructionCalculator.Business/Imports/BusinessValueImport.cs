using System.IO;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class BusinessValueImport : ExcelDataImportBase
    {
        public BusinessValueImport(string fileName) : base(fileName)
        {
            IncludeHeader = true;
        }

        public BusinessValueImport(Stream file) : base(file)
        {
            IncludeHeader = true;
        }


        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var b = new BusinessValue
            {
                Id = cells[row, 1].Text.ConvertData<int>(),
                FileId = FileId,
                Name = cells[row, 2].Text
            };
            Context.BusinessValues.Add(b);
        }
    }
}