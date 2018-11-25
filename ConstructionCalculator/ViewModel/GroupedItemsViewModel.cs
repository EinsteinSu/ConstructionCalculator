using System.Collections.Generic;
using ConstructionCalculator.DataModel;
using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI.Navigation;

namespace ConstructionCalculator.ViewModel
{
    //A View Model for a GroupedItemsPage
    public class GroupedItemsViewModel : ViewModelBase, INavigationAware
    {
        private IEnumerable<SampleDataItem> items;

        public IEnumerable<SampleDataItem> Items
        {
            get => items;
            private set => SetProperty(ref items, value, "Items");
        }

        public void LoadState(object navigationParameter)
        {
            Items = SampleDataSource.Instance.Items;
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