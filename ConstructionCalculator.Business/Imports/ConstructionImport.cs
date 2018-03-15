using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Imports
{
    public class ConstructionImport : ExcelDataImportBase
    {
        public ConstructionImport(string fileName) : base(fileName)
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
                ConstructionValueId = (int) cells[row, 3].Value,
                Jzmj = cells[row, 4].Text,
                Dydcjzmj = (double) cells[row, 5].Value,
                Cs = (int) cells[row, 6].Value,
                Gd = (double) cells[row, 7].Value,
                BusinessValueId = (int) cells[row, 8].Value,
                BusinessFeatureId = (int) cells[row, 9].Value,
                Aqcksl = (int) cells[row, 10].Value,
                Aqckkd = (double) cells[row, 11].Value,
                Zcksl = (int) cells[row, 12].Value,
                Zckkd = cells[row, 13].Text,
                Sy = (int) cells[row, 14].Value,
                Mhq = (int) cells[row, 15].Value,
                Sns = (int) cells[row, 16].Value,
                Zdbj = (int) cells[row, 17].Value,
                Pl = (int) cells[row, 18].Value,
                Kljm = (int) cells[row, 19].Value,
                Ywsl = (int) cells[row, 20].Value,
                Ywwbjl = (int) cells[row, 21].Value,
                Ywsws = (int) cells[row, 22].Value,
                Swsyws = (int) cells[row, 23].Value,
                Swsjl = cells[row, 24].Text,
                Xfdjl = (double) cells[row, 25].Value,
                Ds = (int) cells[row, 26].Value
            };
            Context.Constructions.Add(c);
        }
    }
}