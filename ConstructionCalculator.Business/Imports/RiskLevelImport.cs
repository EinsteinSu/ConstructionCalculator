using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class RiskLevelImport : ExcelDataImportBase
    {
        public RiskLevelImport(string fileName) : base(fileName)
        {
        }

        public RiskLevelImport(Stream stream) : base(stream)
        {
        }

        protected override bool IncludeHeader => false;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var r = new RiskLevel
            {
                MinValue = cells[row, 1].Text.ConvertData<double>(),
                MaxValue = cells[row, 2].Text.ConvertData<double>(),
                Color = cells[row, 3].Text,
                Description = cells[row, 4].Text
            };
            Context.RiskLevels.Add(r);
        }
    }
}
