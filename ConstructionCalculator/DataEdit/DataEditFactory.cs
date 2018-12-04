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
                default:
                    return null;
            }
        }
    }
}