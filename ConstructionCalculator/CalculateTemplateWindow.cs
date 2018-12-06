using System;
using System.Linq;
using System.Windows.Forms;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using DevExpress.XtraEditors;

namespace ConstructionCalculator
{
    public partial class CalculateTemplateWindow : XtraForm
    {
        private readonly ILogPrint _print;

        public CalculateTemplateWindow()
        {
            InitializeComponent();
        }

        public CalculateTemplateWindow(ILogPrint print)
        {
            _print = print;
            InitializeComponent();
            LoadList();
        }

        private void LoadList()
        {
            using (var context = new ConstructionDataContext())
            {
                if (_print != null)
                    context.Database.Log = _print.PrintLog;

                AddListToComboBox(context, FileType.BusinessFeature, comboBoxEditBusinessFeature);
                AddListToComboBox(context, FileType.ConstructionValue, comboBoxEditConstructionValue);
                AddListToComboBox(context, FileType.RiskLevel, comboBoxEditRiskLevel);
                AddListToComboBox(context, FileType.CellMapping, comboBoxEditCellMapping);
                AddListToComboBox(context, FileType.Construction, comboBoxEditConstruction);
            }
        }

        public string BusinessFeature => comboBoxEditBusinessFeature.SelectedItem.ToString();

        public string ConstructionValue => comboBoxEditConstructionValue.SelectedItem.ToString();

        public string RiskLevel => comboBoxEditRiskLevel.SelectedItem.ToString();

        public string CellMapping => comboBoxEditCellMapping.SelectedItem.ToString();

        public string Construction => comboBoxEditConstruction.SelectedItem.ToString();

        private void AddListToComboBox(ConstructionDataContext context, FileType type, ComboBoxEdit comboBox)
        {
            comboBox.Properties.Items.Clear();
            foreach (var file in context.Files.Where(w => w.Type == type)) comboBox.Properties.Items.Add(file.FileName);
        }

        private string Check()
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(comboBoxEditBusinessFeature.SelectedItem.ToString()))
                error += "Please select a business value." + Environment.NewLine;
            if (string.IsNullOrEmpty(comboBoxEditConstructionValue.SelectedItem.ToString()))
                error += "Please select a construction value." + Environment.NewLine;
            if (string.IsNullOrEmpty(comboBoxEditRiskLevel.SelectedItem.ToString()))
                error += "Please select a risk level." + Environment.NewLine;
            if (string.IsNullOrEmpty(comboBoxEditCellMapping.SelectedItem.ToString()))
                error += "Please select a cell mapping." + Environment.NewLine;
            if (string.IsNullOrEmpty(comboBoxEditConstruction.SelectedItem.ToString()))
                error += "Please select a construction." + Environment.NewLine;

            return error;
        }

        private void simpleButtonCalc_Click(object sender, EventArgs e)
        {
            var error = Check();
            if (string.IsNullOrEmpty(error))
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show(error);
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonSaveAs_Click(object sender, EventArgs e)
        {
            //todo: save as a json file
        }

        private void simpleButtonLoadTemplate_Click(object sender, EventArgs e)
        {
            //todo: load a json file to this
        }
    }
}