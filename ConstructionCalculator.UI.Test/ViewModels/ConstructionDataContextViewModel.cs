using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using ConstructionCalculator.UI.Test.Localization;using ConstructionCalculator.UI.Test.ConstructionDataContextDataModel;

namespace ConstructionCalculator.UI.Test.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the ConstructionDataContext data model.
    /// </summary>
    public partial class ConstructionDataContextViewModel : DocumentsViewModel<ConstructionDataContextModuleDescription, IConstructionDataContextUnitOfWork> {

		const string TablesGroup = "Tables";

		const string ViewsGroup = "Views";
	
        /// <summary>
        /// Creates a new instance of ConstructionDataContextViewModel as a POCO view model.
        /// </summary>
        public static ConstructionDataContextViewModel Create() {
            return ViewModelSource.Create(() => new ConstructionDataContextViewModel());
        }

		        static ConstructionDataContextViewModel() {
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata<ConstructionDataContextMetadataProvider>();
        }
        /// <summary>
        /// Initializes a new instance of the ConstructionDataContextViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ConstructionDataContextViewModel type without the POCO proxy factory.
        /// </summary>
        protected ConstructionDataContextViewModel()
		    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        }

        protected override ConstructionDataContextModuleDescription[] CreateModules() {
			return new ConstructionDataContextModuleDescription[] {
                new ConstructionDataContextModuleDescription(ConstructionDataContextResources.BusinessFeaturePlural, "BusinessFeatureCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.BusinessFeatures)),
                new ConstructionDataContextModuleDescription(ConstructionDataContextResources.BusinessValuePlural, "BusinessValueCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.BusinessValues)),
                new ConstructionDataContextModuleDescription(ConstructionDataContextResources.FilePlural, "FileCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Files)),
                new ConstructionDataContextModuleDescription(ConstructionDataContextResources.ConstructionPlural, "ConstructionCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Constructions)),
                new ConstructionDataContextModuleDescription(ConstructionDataContextResources.ConstructionValuePlural, "ConstructionValueCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.ConstructionValues)),
                new ConstructionDataContextModuleDescription(ConstructionDataContextResources.CellMappingPlural, "CellMappingCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.CellMappings)),
                new ConstructionDataContextModuleDescription(ConstructionDataContextResources.RiskLevelPlural, "RiskLevelCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.RiskLevels)),
			};
        }
                	}

    public partial class ConstructionDataContextModuleDescription : ModuleDescription<ConstructionDataContextModuleDescription> {
        public ConstructionDataContextModuleDescription(string title, string documentType, string group, Func<ConstructionDataContextModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}