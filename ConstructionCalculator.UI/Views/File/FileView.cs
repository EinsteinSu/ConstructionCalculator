using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using ConstructionCalculator.ViewModels.File;
using DevExpress.Utils.MVVM;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;

namespace ConstructionCalculator.Views.File
{
    public partial class FileView : DevExpress.XtraEditors.XtraUserControl
    {
        public FileView()
        {
            InitializeComponent();

            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }
        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<FileViewModel>();
            fluentAPI.WithEvent(this, "Load").EventToCommand(x => x.OnLoaded());
            fluentAPI.SetObjectDataSourceBinding(
                bindingSource1, x => x.Entity, x => x.Update());

            fluentAPI.BindCommand((ISupportCommandBinding)windowsUIButtonPanelMain.Buttons[0], x => x.Save());
            fluentAPI.BindCommand((ISupportCommandBinding)windowsUIButtonPanelMain.Buttons[1], x => x.SaveAndClose());
            fluentAPI.BindCommand((ISupportCommandBinding)windowsUIButtonPanelMain.Buttons[2], x => x.SaveAndNew());
            fluentAPI.BindCommand((ISupportCommandBinding)windowsUIButtonPanelMain.Buttons[3], x => x.Reset());
            fluentAPI.BindCommand((ISupportCommandBinding)windowsUIButtonPanelMain.Buttons[4], x => x.Delete());
            fluentAPI.BindCommand((ISupportCommandBinding)windowsUIButtonPanelCloseButton.Buttons[0], x => x.Close());
        }
    }
}
