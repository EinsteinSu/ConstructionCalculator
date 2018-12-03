using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataEdit;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;

namespace ConstructionCalculator
{
    public partial class DataEditControl : XtraUserControl
    {
        public DataEditControl()
        {
            InitializeComponent();
            gridView.OptionsBehavior.AutoPopulateColumns = true;
        }

        public ConstructionDataContext Context { get; set; }

        public IDataEdit DataEdit { get; set; }

        public void Initialize()
        {
            LoadData();
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Print") gridControl.ShowRibbonPrintPreview();
            if (e.Button.Properties.Caption == "Refresh") LoadData();
            if (e.Button.Properties.Caption == "New")
            {
                AddNew();
            }

            if (e.Button.Properties.Caption == "Delete")
            {
                Remove();
            }
            if (e.Button.Properties.Caption == "Save")
            {
                Context.SaveChanges();
            }
        }

        private void Remove()
        {
            var item = gridView.GetFocusedRow();
            DataEdit.Remove(item);
        }

        private void Save()
        {
            DataEdit.Save(gridControl.DataSource, null);
        }

        private void AddNew()
        {
            DataEdit.Add();
        }

        private void LoadData()
        {
            DataEdit.BindingData(gridControl);
        }
    }
}