using System;
using ConstructionCalculator.Commons;
using ConstructionCalculator.Interfaces;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;

namespace ConstructionCalculator.ViewModels.File
{
    [POCOViewModel]
    public class FileViewModel : SingleObjectViewModel<DataAccess.File, int, IConstructionCalculatorUnitOfWork>
    {
        public static FileViewModel Create(IUnitOfWorkFactory<IConstructionCalculatorUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new FileViewModel(unitOfWorkFactory));
        }

        protected FileViewModel(IUnitOfWorkFactory<IConstructionCalculatorUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Files, x => x.Id)
        {
        }
    }
}