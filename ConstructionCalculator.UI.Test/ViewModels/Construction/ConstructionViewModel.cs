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
    /// Represents the single Construction object view model.
    /// </summary>
    public partial class ConstructionViewModel : SingleObjectViewModel<Construction, int, IConstructionDataContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ConstructionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ConstructionViewModel Create(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ConstructionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ConstructionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ConstructionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ConstructionViewModel(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Constructions, x => x.Jzmc) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of BusinessFeatures for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<BusinessFeature> LookUpBusinessFeatures {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ConstructionViewModel x) => x.LookUpBusinessFeatures,
                    getRepositoryFunc: x => x.BusinessFeatures);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of ConstructionValues for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<ConstructionValue> LookUpConstructionValues {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ConstructionViewModel x) => x.LookUpConstructionValues,
                    getRepositoryFunc: x => x.ConstructionValues);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Files for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<File> LookUpFiles {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ConstructionViewModel x) => x.LookUpFiles,
                    getRepositoryFunc: x => x.Files);
            }
        }

    }
}
