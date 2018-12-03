using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.Business.Cruds
{
    public interface IFileRetrieve<out T>
    {
        IEnumerable<T> GetEntries(int fileId);
    }
}
