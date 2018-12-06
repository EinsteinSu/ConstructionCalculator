using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataEdit;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace ConstructionCalculator
{
    public partial class DataEditControl : XtraUserControl
    {
        public DataEditControl()
        {
            InitializeComponent();
            gridControl1.ShowOnlyPredefinedDetails = true;
        }

        public ConstructionDataContext Context { get; set; }

        public IDataEdit DataEdit { get; set; }

        public GridControl GridControl => gridControl1;

        public object FocusedRow => gridView1.GetFocusedRow();
    }
}