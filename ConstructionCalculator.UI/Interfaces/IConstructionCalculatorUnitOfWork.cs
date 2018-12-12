using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.DataAccess;
using DevExpress.Mvvm.DataModel;

namespace ConstructionCalculator.Interfaces
{
    public interface IConstructionCalculatorUnitOfWork : IUnitOfWork
    {
        IRepository<File, int> Files { get;  }

        IRepository<BusinessValue, int> BusinessValues { get;  }

        IRepository<BusinessFeature, int> BusinessFeatures { get;  }
    }
}
