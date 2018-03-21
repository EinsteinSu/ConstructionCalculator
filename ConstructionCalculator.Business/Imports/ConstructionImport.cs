using System;
using System.Collections.Generic;
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

        public Action<Construction> SomeAction { get; set; }

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
                BusinessFeatureId = cells[row, 8].Text.ConvertData(0),
                Aqcksl = cells[row, 9].Text.ConvertData(0),
                Aqckkd = cells[row, 10].Text.ConvertData<double>(),
                Zcksl = cells[row, 11].Text.ConvertData(0),
                Zckkd = cells[row, 12].Text,
                Sy = cells[row, 13].Text.ConvertData(0),
                Mhq = cells[row, 14].Text.ConvertData(0),
                Sns = cells[row, 15].Text.ConvertData(0),
                Zdbj = cells[row, 16].Text.ConvertData(0),
                Pl = cells[row, 17].Text.ConvertData(0),
                Kljm = cells[row, 18].Text.ConvertData(0),
                Ywsl = cells[row, 19].Text.ConvertData(0),
                Ywwbjl = cells[row, 20].Text.ConvertData(0),
                Ywsws = cells[row, 21].Text.ConvertData(0),
                Swsyws = cells[row, 22].Text.ConvertData(0),
                Swsjl = cells[row, 23].Text,
                Xfdjl = cells[row, 24].Text.ConvertData<double>(),
                Ds = cells[row, 25].Text.ConvertData(0)
            };
            Context.Constructions.Add(c);
            SomeAction?.Invoke(c);
        }
    }
}