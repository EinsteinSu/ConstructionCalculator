using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.Business.Imports
{
    public class ImportFactory
    {
        //todo: to be tested
        public static ExcelDataImportBase GetImporter(FileType type, string fileName)
        {
            switch (type)
            {
                case FileType.BusinessFeature:
                    return new BusinesFeatureImport(fileName);
                case FileType.BusinessValue:
                    return new BusinessValueImport(fileName);
                case FileType.CellMapping:
                    return new CellMappingImport(fileName);
                case FileType.Construction:
                    return new ConstructionImport(fileName);
                case FileType.ConstructionValue:
                    return new ConstructionValueImport(fileName);
                case FileType.RiskLevel:
                    return new RiskLevelImport(fileName);
                default:
                    return null;
            }
        }
    }
}