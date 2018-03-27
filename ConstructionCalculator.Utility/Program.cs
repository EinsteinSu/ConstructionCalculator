using System;
using System.IO;
using ConstructionCalculator.Business;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using log4net;
using log4net.Config;
using OfficeOpenXml;

namespace ConstructionCalculator.Utility
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger("Utility");

        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            XmlConfigurator.Configure();
            var parameter = args[0].ToLower();
            switch (parameter)
            {
                case "clean":
                    Log.InfoFormat("Action: Cleanup database");
                    Cleanup();
                    break;
                case "import":
                    Log.InfoFormat("Action: Import data");
                    ImportFromFolder();
                    break;
                case "calc":
                    var folder = args[1];
                    Log.InfoFormat($"Action: Calculat from folder ${folder}");
                    foreach (var file in Directory.GetFiles(folder, "*.xlsx"))
                    {
                        Log.InfoFormat($"Processing {file}");
                        CalculatorHelper.CalcAndExportExcel(file);
                    }
                    break;
                case "transfer":
                    Log.InfoFormat($"Action: Transfer from folder {args[1]}");
                    TransferToXlsx(args[1]);
                    break;
            }
        }

        public static void TransferToXlsx(string path)
        {
            foreach (var fileName in Directory.GetFiles(path))
                using (var excel = new ExcelPackage(new FileInfo(fileName)))
                {
                    excel.SaveAs(new FileInfo(fileName + "x"));
                }
        }

        public static void Cleanup()
        {
            using (var context = new ConstructionDataContext("Construction"))
            {
                Log.InfoFormat(context.Database.Connection.ConnectionString);
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