using System.IO;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class RiskLevelImport : ExcelDataImportBase
    {
        public RiskLevelImport(string fileName) : base(fileName)
        {
            IncludeHeader = false;
        }

        public RiskLevelImport(Stream stream) : base(stream)
        {
            IncludeHeader = false;
        }

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var r = new RiskLevel
            {
                MinValue = cells[row, 1].Text.ConvertData<double>(),
                FileId = FileId,
                MaxValue = cells[row, 2].Text.ConvertData<double>(),
                Color = cells[row, 3].Text,
                Description = cells[row, 4].Text
            };
            Context.RiskLevels.Add(r);
        }
    }
}