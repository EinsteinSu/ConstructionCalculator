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
    /// Represents the Constructions collection view model.
    /// </summary>
    public partial class ConstructionCollectionViewModel : CollectionViewModel<Construction, int, IConstructionDataContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ConstructionCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ConstructionCollectionViewModel Create(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ConstructionCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ConstructionCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ConstructionCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ConstructionCollectionViewModel(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Constructions) {
        }
    }
}