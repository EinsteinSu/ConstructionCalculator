using ConstructionCalculator.DataModel;
using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI.Navigation;

namespace ConstructionCalculator.ViewModel
{
    //A View Model for an ItemDetailPage
    public class ItemDetailViewModel : ViewModelBase, INavigationAware
    {
        private SampleDataItem selectedItem;

        public SampleDataItem SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value, "SelectedItem");
        }

        private void LoadState(object navigationParameter)
        {
            var item = SampleDataSource.GetItem((string) navigationParameter);
            SelectedItem = item;
        }

        #region INavigationAware Members

        public void NavigatedFrom(NavigationEventArgs e)
        {
        }

        public void NavigatedTo(NavigationEventArgs e)
        {
            LoadState(e.Parameter);
        }

        public void NavigatingFrom(NavigatingEventArgs e)
        {
        }

        #endregion
    }
}