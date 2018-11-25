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
    /// Represents the Files collection view model.
    /// </summary>
    public partial class FileCollectionViewModel : CollectionViewModel<File, int, IConstructionDataContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of FileCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static FileCollectionViewModel Create(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new FileCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the FileCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the FileCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected FileCollectionViewModel(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Files) {
        }
    }
}