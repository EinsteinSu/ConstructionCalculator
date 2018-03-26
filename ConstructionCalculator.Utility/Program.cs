using System;
using System.Data.Entity;
using System.IO;
using ConstructionCalculator.Business;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.Utility
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            var parameter = args[0].ToLower();
            switch (parameter)
            {
                case "clean":
                    Cleanup();
                    break;
                case "import":
                    ImportFromFolder();
                    break;
                case "calc":
                    var folder = args[1];
                    foreach (var file in Directory.GetFiles(folder, "*.xlsx"))
                        CalculatorHelper.CalcAndExportExcel(file);
                    break;
            }
        }

        public static void Cleanup()
        {
            using (var context = new ConstructionDataContext("Construction"))
            {
                Console.WriteLine(context.Database.Connection.ConnectionString);
                context.Database.ExecuteSqlCommand("Delete From Constructions");
                context.Database.ExecuteSqlCommand("Delete From BusinessFeatures");
                context.Database.ExecuteSqlCommand("Delete From BusinessValues");
                context.Database.ExecuteSqlCommand("Delete From ConstructionValues");
                context.Database.ExecuteSqlCommand("Delete From CellMappings");
                context.Database.ExecuteSqlCommand("Delete From RiskLevels");
            }
        }

        private static void ImportFromFolder()
        {
            var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImportData");
            ExcelDataImportBase importer = new CellMappingImport(Path.Combine(folder, "CellMapping.xlsx"));
            importer.Import();
            importer = new ConstructionValueImport(Path.Combine(folder, "ConstructionValue.xlsx"));
            importer.Import();
            importer = new BusinessValueImport(Path.Combine(folder, "BusinessValue.xlsx"));
            importer.Import();
            importer = new BusinesFeatureImport(Path.Combine(folder, "BusinessFeature.xlsx"));
            importer.Import();
            importer = new RiskLevelImport(Path.Combine(folder, "RiskLevel.xlsx"));
            importer.Import();
        }
    }
}