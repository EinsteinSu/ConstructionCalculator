using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Utilities;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;

namespace ConstructionCalculator
{
    public partial class DataEditControl : XtraUserControl
    {
        protected DataFactory dataFactory;

        public DataEditControl()
        {
            InitializeComponent();
        }

        public int FileId { get; set; }

        public ConstructionDataContext Context { get; set; }

        public void Initialize()
        {
            dataFactory = new DataFactory(FileId, Context);
            LoadData();
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Print") gridControl.ShowRibbonPrintPreview();
            if (e.Button.Properties.Caption == "Refresh") LoadData();
            if (e.Button.Properties.Caption == "New") AddNew();
            if (e.Button.Properties.Caption == "Save") Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }

        private void AddNew()
        {
            dataFactory.AddItem(FileId);
        }

        private void LoadData()
        {
            gridControl.DataSource = dataFactory.GetList();
        }
    }
}