using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.Business.Imports;

namespace ConstructionCalculator.Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameter = args[0];
            switch (parameter)
            {
                case "import":
                    //todo process all files from data folder
                    ImportFromFolder();
                    break;
            }
        }

        static void ImportFromFolder()
        {
            var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImportData");
            ExcelDataImportBase importer = new CellMappingImport(Path.Combine(folder, "CellMapping.xlsx"));
            importer.Import();
            importer = new ConstructionValueImport(Path.Combine(folder, "ConstructionValue.xlsx"));
            importer.Import();
            importer = new BusinesFeatureImport(Path.Combine(folder, "BusinessFeature.xlsx"));
            importer.Import();
            importer = new BusinessValueImport(Path.Combine(folder, "BusinessValue.xlsx"));
            importer.Import();
            importer = new RiskLevelImport(Path.Combine(folder, "RiskLevel.xlsx"));
            importer.Import();
        }
    }
}
