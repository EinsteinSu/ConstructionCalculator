using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using ConstructionCalculator.UI.Test.ConstructionDataContextDataModel;
using ConstructionCalculator.UI.Test.Common;
using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.UI.Test.ViewModels {

    /// <summary>
    /// Represents the single BusinessFeature object view model.
    /// </summary>
    public partial class BusinessFeatureViewModel : SingleObjectViewModel<BusinessFeature, int, IConstructionDataContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of BusinessFeatureViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static BusinessFeatureViewModel Create(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new BusinessFeatureViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the BusinessFeatureViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the BusinessFeatureViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected BusinessFeatureViewModel(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.BusinessFeatures, x => x.Name) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of BusinessValues for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<BusinessValue> LookUpBusinessValues {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (BusinessFeatureViewModel x) => x.LookUpBusinessValues,
                    getRepositoryFunc: x => x.BusinessValues);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Files for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<File> LookUpFiles {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (BusinessFeatureViewModel x) => x.LookUpFiles,
                    getRepositoryFunc: x => x.Files);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Constructions for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Construction> LookUpConstructions {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (BusinessFeatureViewModel x) => x.LookUpConstructions,
                    getRepositoryFunc: x => x.Constructions);
            }
        }


        /// <summary>
        /// The view model for the BusinessFeatureConstructions detail collection.
        /// </summary>
        public CollectionViewModelBase<Construction, Construction, int, IConstructionDataContextUnitOfWork> BusinessFeatureConstructionsDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (BusinessFeatureViewModel x) => x.BusinessFeatureConstructionsDetails,
                    getRepositoryFunc: x => x.Constructions,
                    foreignKeyExpression: x => x.BusinessFeatureId,
                    navigationExpression: x => x.BusinessFeature);
            }
        }
    }
}
