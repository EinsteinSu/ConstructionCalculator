using System;
using System.Linq;
using System.Windows.Forms;
using ConstructionCalculator.Business;
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

        public CalculationTemplate Template { get; set; }

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

        private void AddListToComboBox(ConstructionDataContext context, FileType type, ComboBoxEdit comboBox)
        {
            comboBox.Properties.Items.Clear();
            foreach (var file in context.Files.Where(w => w.Type == type)) comboBox.Properties.Items.Add(file);
        }

        private string Check()
        {
            var error = string.Empty;
            error += CheckComboBoxItem(comboBoxEditBusinessFeature, "business value");
            error += CheckComboBoxItem(comboBoxEditConstructionValue, "construction value");
            error += CheckComboBoxItem(comboBoxEditRiskLevel, "risk level");
            error += CheckComboBoxItem(comboBoxEditCellMapping, "cell mapping");
            error += CheckComboBoxItem(comboBoxEditConstruction, "construction");
            return error;
        }

        private string CheckComboBoxItem(ComboBoxEdit comboBox, string name)
        {
            var error = string.Empty;
            if (comboBox.SelectedItem == null || string.IsNullOrEmpty(comboBox.SelectedItem.ToString()))
                error += $"Please select a {name}" + Environment.NewLine;
            return error;
        }

        private void simpleButtonCalc_Click(object sender, EventArgs e)
        {
            var error = Check();
            if (string.IsNullOrEmpty(error))
            {
                Template = new CalculationTemplate
                {
                    BusinessFeature = GetTemplate(comboBoxEditBusinessFeature),
                    ConstructionValue = GetTemplate(comboBoxEditConstructionValue),
                    RiskLevel = GetTemplate(comboBoxEditRiskLevel),
                    CellMapping = GetTemplate(comboBoxEditCellMapping)
                };

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private Table GetTemplate(ComboBoxEdit comboBox)
        {
            var templateTable = new Table();
            var file = comboBox.SelectedItem as File;
            if (file == null)
                throw new Exception("File was not found.");
            templateTable.Id = file.Id;
            templateTable.Name = file.FileName;
            return templateTable;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonSaveAs_Click(object sender, EventArgs e)
        {
            var error = Check();
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                DefaultExt = ".template",
                Filter = @"Template Files (.template)|*.template"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                //todo: implement with Newtonsoft.Json
            }
        }

        private void simpleButtonLoadTemplate_Click(object sender, EventArgs e)
        {
            //todo: load a json file to this
        }
    }
}