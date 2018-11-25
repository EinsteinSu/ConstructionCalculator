using ConstructionCalculator.DataAccess;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EF6;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionCalculator.UI.Test.ConstructionDataContextDataModel {

    /// <summary>
    /// A ConstructionDataContextUnitOfWork instance that represents the run-time implementation of the IConstructionDataContextUnitOfWork interface.
    /// </summary>
    public class ConstructionDataContextUnitOfWork : DbUnitOfWork<ConstructionDataContext>, IConstructionDataContextUnitOfWork {

        public ConstructionDataContextUnitOfWork(Func<ConstructionDataContext> contextFactory)
            : base(contextFactory) {
        }

        IRepository<BusinessFeature, int> IConstructionDataContextUnitOfWork.BusinessFeatures {
            get { return GetRepository(x => x.Set<BusinessFeature>(), (BusinessFeature x) => x.Id); }
        }

        IRepository<BusinessValue, int> IConstructionDataContextUnitOfWork.BusinessValues {
            get { return GetRepository(x => x.Set<BusinessValue>(), (BusinessValue x) => x.Id); }
        }

        IRepository<File, int> IConstructionDataContextUnitOfWork.Files {
            get { return GetRepository(x => x.Set<File>(), (File x) => x.Id); }
        }

        IRepository<Construction, int> IConstructionDataContextUnitOfWork.Constructions {
            get { return GetRepository(x => x.Set<Construction>(), (Construction x) => x.Id); }
        }

        IRepository<ConstructionValue, int> IConstructionDataContextUnitOfWork.ConstructionValues {
            get { return GetRepository(x => x.Set<ConstructionValue>(), (ConstructionValue x) => x.Id); }
        }

        IRepository<CellMapping, int> IConstructionDataContextUnitOfWork.CellMappings {
            get { return GetRepository(x => x.Set<CellMapping>(), (CellMapping x) => x.Id); }
        }

        IRepository<RiskLevel, int> IConstructionDataContextUnitOfWork.RiskLevels {
            get { return GetRepository(x => x.Set<RiskLevel>(), (RiskLevel x) => x.Id); }
        }
    }
}
