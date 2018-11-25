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
    /// Represents the single CellMapping object view model.
    /// </summary>
    public partial class CellMappingViewModel : SingleObjectViewModel<CellMapping, int, IConstructionDataContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of CellMappingViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static CellMappingViewModel Create(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new CellMappingViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the CellMappingViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CellMappingViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CellMappingViewModel(IUnitOfWorkFactory<IConstructionDataContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.CellMappings, x => x.ColumnName) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Files for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<File> LookUpFiles {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (CellMappingViewModel x) => x.LookUpFiles,
                    getRepositoryFunc: x => x.Files);
            }
        }

    }
}
