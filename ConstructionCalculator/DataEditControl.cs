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
            gridView1.OptionsBehavior.AutoPopulateColumns = true;
        }

        public ConstructionDataContext Context { get; set; }

        public IDataEdit DataEdit { get; set; }

        public GridControl GridControl { get; private set; }
    }
}