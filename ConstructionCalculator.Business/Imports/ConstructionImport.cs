using System.IO;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class ConstructionImport : ExcelDataImportBase
    {
        public ConstructionImport(string fileName) : base(fileName)
        {
        }

        public ConstructionImport(Stream file) : base(file)
        {
        }

        protected override bool IncludeHeader => true;

        protected override int SheetNumber => 1;

        public override void ImportRow(ExcelRange cells, int row)
        {
            var c = new Construction
            {
                Jzmc = cells[row, 1].Text,
                Dtbh = cells[row, 2].Text,
                ConstructionValueId = cells[row, 3].Text.ConvertData(0),
                Jzmj = cells[row, 4].Text,
                Dydcjzmj = cells[row, 5].Text.ConvertData<double>(),
                Cs = cells[row, 6].Text.ConvertData(0),
                Gd = cells[row, 7].Text.ConvertData<double>(),
                BusinessValueId = cells[row, 8].Text.ConvertData(0),
                BusinessFeatureId = cells[row, 9].Text.ConvertData(0),
                Aqcksl = cells[row, 10].Text.ConvertData(0),
                Aqckkd = cells[row, 11].Text.ConvertData<double>(),
                Zcksl = cells[row, 12].Text.ConvertData(0),
                Zckkd = cells[row, 13].Text,
                Sy = cells[row, 14].Text.ConvertData(0),
                Mhq = cells[row, 15].Text.ConvertData(0),
                Sns = cells[row, 16].Text.ConvertData(0),
                Zdbj = cells[row, 17].Text.ConvertData(0),
                Pl = cells[row, 18].Text.ConvertData(0),
                Kljm = cells[row, 19].Text.ConvertData(0),
                Ywsl = cells[row, 20].Text.ConvertData(0),
                Ywwbjl = cells[row, 21].Text.ConvertData(0),
                Ywsws = cells[row, 22].Text.ConvertData(0),
                Swsyws = cells[row, 23].Text.ConvertData(0),
                Swsjl = cells[row, 24].Text,
                Xfdjl = cells[row, 25].Text.ConvertData<double>(),
                Ds = cells[row, 26].Text.ConvertData(0)
            };
            Context.Constructions.Add(c);
        }
    }
}