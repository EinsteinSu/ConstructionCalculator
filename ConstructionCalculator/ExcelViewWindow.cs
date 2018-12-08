using System.IO;
using DevExpress.XtraBars.Ribbon;

namespace ConstructionCalculator
{
    public partial class ExcelViewWindow : RibbonForm
    {
        public ExcelViewWindow()
        {
            InitializeComponent();
        }

        public void LoadExcel(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                spreadsheetControl1.LoadDocument(stream);
            }
        }
    }
}