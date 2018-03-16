using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class BusinessValueImport : ExcelDataImportBase
    {
        public BusinessValueImport(string fileName) : base(fileName)
        {
        }

        protected override bool IncludeHeader => false;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var b = new BusinessValue();
            b.Id = (int) cells[row, 1].Value;
            b.Name = cells[row, 2].Text;
            b.FeatureId = (int) cells[row, 3].Value;
            b.FeatureName = cells[row, 4].Text;
            Context.BusinessValues.Add(b);
        }
    }
}