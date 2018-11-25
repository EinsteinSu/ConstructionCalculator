using ConstructionCalculator.DataAccess;
using DevExpress.Mvvm.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionCalculator.UI.Test.ConstructionDataContextDataModel {

    /// <summary>
    /// IConstructionDataContextUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IConstructionDataContextUnitOfWork : IUnitOfWork {
        
        /// <summary>
        /// The BusinessFeature entities repository.
        /// </summary>
		IRepository<BusinessFeature, int> BusinessFeatures { get; }
        
        /// <summary>
        /// The BusinessValue entities repository.
        /// </summary>
		IRepository<BusinessValue, int> BusinessValues { get; }
        
        /// <summary>
        /// The File entities repository.
        /// </summary>
		IRepository<File, int> Files { get; }
        
        /// <summary>
        /// The Construction entities repository.
        /// </summary>
		IRepository<Construction, int> Constructions { get; }
        
        /// <summary>
        /// The ConstructionValue entities repository.
        /// </summary>
		IRepository<ConstructionValue, int> ConstructionValues { get; }
        
        /// <summary>
        /// The CellMapping entities repository.
        /// </summary>
		IRepository<CellMapping, int> CellMappings { get; }
        
        /// <summary>
        /// The RiskLevel entities repository.
        /// </summary>
		IRepository<RiskLevel, int> RiskLevels { get; }
    }
}
