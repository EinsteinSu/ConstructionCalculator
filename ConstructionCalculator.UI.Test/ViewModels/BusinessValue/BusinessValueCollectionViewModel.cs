using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using ConstructionCalculator.UI.Test.ConstructionDataContextDataModel;
using ConstructionCalculator.UI.Test.Common;
using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.UI.Test.ViewModels {

    /// <summary>
    /// Represents the BusinessValues collection view model.
    /// </summary>
    public partial class BusinessValueCollectionViewModel : CollectionViewModel<BusinessValue, int, IConstructionDataContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of BusinessValueCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static BusinessValueCollectionViewModel Create(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new BusinessValueCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the BusinessValueCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the BusinessValueCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected BusinessValueCollectionViewModel(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.BusinessValues) {
        }
    }
}