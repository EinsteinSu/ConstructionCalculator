using System;
using System.Linq;
using ConstructionCalculator.Commons;
using ConstructionCalculator.Interfaces;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;

namespace ConstructionCalculator.ViewModels.File
{


    public class FileCollectionViewModel : CollectionViewModel<DataAccess.File, int, IConstructionCalculatorUnitOfWork>
    {
        public static FileCollectionViewModel Create(IUnitOfWorkFactory<IConstructionCalculatorUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new FileCollectionViewModel(unitOfWorkFactory));
        }

        protected FileCollectionViewModel(IUnitOfWorkFactory<IConstructionCalculatorUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Files)
        {
        }
    }
}