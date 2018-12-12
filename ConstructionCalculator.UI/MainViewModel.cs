using ConstructionCalculator.Commons;
using ConstructionCalculator.Interfaces;
using ConstructionCalculator.Modules;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;

namespace ConstructionCalculator
{
    [POCOViewModel]
    public class MainViewModel:DocumentsViewModel<FunctionalityModuleDescription,IConstructionCalculatorUnitOfWork>
    {
        INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }
        protected MainViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory())
        {
        }
        protected MainViewModel(IUnitOfWorkFactory<IConstructionCalculatorUnitOfWork> unitOfWorkFactory) : base(unitOfWorkFactory)
        {
        }

        protected override void OnActiveModuleChanged(FunctionalityModuleDescription oldModule)
        {
            if (ActiveModule != null)
            {
                NavigationService?.ClearNavigationHistory();
            }
            base.OnActiveModuleChanged(oldModule);
        }

        private const string Group = "Group";
        protected override FunctionalityModuleDescription[] CreateModules()
        {
            return new []
            {
                new FunctionalityModuleDescription("Files", "FileCollectionView", Group,
                    GetPeekCollectionViewModelFactory(x => x.Files)),
                new FunctionalityModuleDescription("Business Values", "BusinessValueCollectionView", Group,
                    GetPeekCollectionViewModelFactory(x => x.Files)),
                new FunctionalityModuleDescription("Business Features", "BusinessFeatureCollectionView", Group,
                    GetPeekCollectionViewModelFactory(x => x.Files)),
            };
        }
    }
}