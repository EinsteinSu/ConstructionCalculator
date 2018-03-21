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
    public class BusinesFeatureImport : ExcelDataImportBase
    {
        public BusinesFeatureImport(string fileName) : base(fileName)
        {
        }

        public BusinesFeatureImport(Stream stream) : base(stream)
        {
        }

        protected override bool IncludeHeader => true;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var f = new BusinessFeature
            {
                Id = cells[row, 1].Text.ConvertData(0),
                Name = cells[row, 2].Text,
                BusinessValueId = cells[row, 3].Text.ConvertData(0),
                GdQi = cells[row, 4].Text.ConvertData<double>(),
                YdQm = cells[row, 5].Text.ConvertData<double>(),
                Hzmyyzi = cells[row, 6].Text.ConvertData<double>(),
                Hdyza = cells[row, 7].Text.ConvertData<double>(),
                Ylyzd = cells[row, 8].Text.ConvertData<double>(),
                Sssjxzzp = cells[row, 9].Text.ConvertData<double>(),
                Ssrs = cells[row, 10].Text.ConvertData<double>(),
                Jzyz = cells[row, 11].Text.ConvertData<double>()
            };
            Context.BusinessFeatures.Add(f);
        }
    }
}
