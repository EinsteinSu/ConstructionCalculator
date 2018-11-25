using ConstructionCalculator.DataAccess;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionCalculator.UI.Test.ConstructionDataContextDataModel {

    /// <summary>
    /// A ConstructionDataContextDesignTimeUnitOfWork instance that represents the design-time implementation of the IConstructionDataContextUnitOfWork interface.
    /// </summary>
    public class ConstructionDataContextDesignTimeUnitOfWork : DesignTimeUnitOfWork, IConstructionDataContextUnitOfWork {

        /// <summary>
        /// Initializes a new instance of the ConstructionDataContextDesignTimeUnitOfWork class.
        /// </summary>
        public ConstructionDataContextDesignTimeUnitOfWork() {
        }

        IRepository<BusinessFeature, int> IConstructionDataContextUnitOfWork.BusinessFeatures {
            get { return GetRepository((BusinessFeature x) => x.Id); }
        }

        IRepository<BusinessValue, int> IConstructionDataContextUnitOfWork.BusinessValues {
            get { return GetRepository((BusinessValue x) => x.Id); }
        }

        IRepository<File, int> IConstructionDataContextUnitOfWork.Files {
            get { return GetRepository((File x) => x.Id); }
        }

        IRepository<Construction, int> IConstructionDataContextUnitOfWork.Constructions {
            get { return GetRepository((Construction x) => x.Id); }
        }

        IRepository<ConstructionValue, int> IConstructionDataContextUnitOfWork.ConstructionValues {
            get { return GetRepository((ConstructionValue x) => x.Id); }
        }

        IRepository<CellMapping, int> IConstructionDataContextUnitOfWork.CellMappings {
            get { return GetRepository((CellMapping x) => x.Id); }
        }

        IRepository<RiskLevel, int> IConstructionDataContextUnitOfWork.RiskLevels {
            get { return GetRepository((RiskLevel x) => x.Id); }
        }
    }
}
