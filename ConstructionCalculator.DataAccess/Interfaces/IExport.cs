using System.Collections.Generic;

namespace ConstructionCalculator.DataAccess.Interfaces
{
    public interface IExport
    {
        List<string> GetHeader();

        List<object> GetRow();
    }
}