using System.Windows.Forms;
using ConstructionCalculator.ViewModels.File;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace ConstructionCalculator.Views.File
{
    public partial class FileCollectionView : XtraUserControl
    {
        public FileCollectionView()
        {
            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }

        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<FileCollectionViewModel>();
            fluentAPI.WithEvent(this, "Load").EventToCommand(x => x.OnLoaded());
            // We want to show the Entities collection in grid and react on this collection external changes (Reload, server-side Filtering)
            fluentAPI.SetBinding(gridControl, gControl => gControl.DataSource, x => x.Entities);
            // We want to show loading-indicator when data is loading asynchronously
            fluentAPI.SetBinding(gridView, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            // We want to proceed the Edit command when row double-clicked
            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick").EventToCommand(
                x => x.Edit(null),
                x => x.SelectedEntity,
                args => args.Clicks == 2 && args.Button == MouseButtons.Left);
            // We want to synchronize the ViewModel.SelectedEntity and the GridView.FocusedRowRandle in two-way manner
            fluentAPI.WithEvent<GridView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity,
                    args => args.Row as DataAccess.File,
                    (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            //We want to show ribbon print preview when bbiPrintPreview clicked
            fluentAPI.BindCommand((ISupportCommandBinding) windowsUIButtonPanel.Buttons[0], x => x.New());
            fluentAPI.BindCommand((ISupportCommandBinding) windowsUIButtonPanel.Buttons[1], (x, p) => x.Edit(p),
                x => x.SelectedEntity);
            fluentAPI.BindCommand((ISupportCommandBinding) windowsUIButtonPanel.Buttons[2], (x, p) => x.Delete(p),
                x => x.SelectedEntity);
            fluentAPI.BindCommand((ISupportCommandBinding) windowsUIButtonPanel.Buttons[3], x => x.Refresh());
            ((WindowsUIButton) windowsUIButtonPanel.Buttons[5]).Click += (s, e) =>
            {
                gridControl.ShowRibbonPrintPreview();
            };
        }
    }
}