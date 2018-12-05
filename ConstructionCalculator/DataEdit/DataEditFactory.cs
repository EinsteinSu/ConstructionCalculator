using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.DataEdit
{
    public class DataEditFactory
    {
        public static IDataEdit GetDataEdit(File file, ConstructionDataContext context)
        {
            switch (file.Type)
            {
                case FileType.BusinessValue:
                    return new BusinessValueEdit(file.Id, context);
                case FileType.BusinessFeature:
                    return new BusinessFeatureEdit(file.Id, context);
                case FileType.RiskLevel:
                    return new RiskLevelEdit(file.Id, context);
                case FileType.Construction:
                    return new ConstructionEdit(file.Id, context);
                case FileType.CellMapping:
                    return new CellMappingEdit(file.Id, context);
                case FileType.ConstructionValue:
                    return new ConstructionValueEdit(file.Id, context);
                default:
                    return null;
            }
        }
    }
}