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

        protected override bool IncludeHeader => false;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var b = new BusinessValue();
            b.Id = cells[row, 1].Text.ConvertData<int>();
            b.Name = cells[row, 2].Text;
            b.FeatureId = cells[row, 3].Text.ConvertData<int>();
            b.FeatureName = cells[row, 4].Text;
            b.GdQi = cells[row, 5].Text.ConvertData<double>();
            b.YdQm = cells[row, 6].Text.ConvertData<double>();
            b.Hzmyyzi = cells[row, 7].Text.ConvertData<double>();
            b.Hdyza = cells[row, 8].Text.ConvertData<double>();
            b.Ylyzd = cells[row, 9].Text.ConvertData<double>();
            b.Sssjxzzp = cells[row, 10].Text.ConvertData<double>();
            b.Ssrs = cells[row, 11].Text.ConvertData<double>();
            b.Jzyz = cells[row, 12].Text.ConvertData<double>();
            Context.BusinessValues.Add(b);
        }
    }
}