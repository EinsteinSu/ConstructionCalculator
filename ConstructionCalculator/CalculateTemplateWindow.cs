using System;
using System.Linq;
using System.Windows.Forms;
using ConstructionCalculator.Business;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using DevExpress.Data.Helpers;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;

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
                cmbListConstructions.Properties.Items.Clear();
                foreach (var file in context.Files.Where(w => w.Type == FileType.Construction))
                {
                    cmbListConstructions.Properties.Items.Add(file);
                }
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
            if (cmbListConstructions.Properties.Items.All(a => a.CheckState != CheckState.Checked))
            {
                error += "Please select a constructions.";
            }
            return error;
        }

        private string CheckComboBoxItem(ComboBoxEdit comboBox, string name)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(comboBox.SelectedItem?.ToString()))
                error += $"Please select a {name}." + Environment.NewLine;
            return error;
        }

        private void simpleButtonCalc_Click(object sender, EventArgs e)
        {
            var error = Check();
            if (string.IsNullOrEmpty(error))
            {
                SetTempate();
                //todo: calc
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void SetTempate()
        {
            Template = new CalculationTemplate
            {
                BusinessFeature = GetTemplate(comboBoxEditBusinessFeature),
                ConstructionValue = GetTemplate(comboBoxEditConstructionValue),
                RiskLevel = GetTemplate(comboBoxEditRiskLevel),
                CellMapping = GetTemplate(comboBoxEditCellMapping),
                Constructions = new List<Table>()
            };
            foreach (CheckedListBoxItem item in cmbListConstructions.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    if (item.Value is File file)
                    {
                        Template.Constructions.Add(new Table
                        {
                            Id = file.Id,
                            Name = file.FileName
                        });
                    }
                }
            }
        }

        private Table GetTemplate(ComboBoxEdit comboBox)
        {
            var templateTable = new Table(); if (!(comboBox.SelectedItem is File file))
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

                SetTempate();
                System.IO.File.WriteAllText(saveDialog.FileName, JsonConvert.SerializeObject(Template));
            }
        }

        private void simpleButtonLoadTemplate_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                DefaultExt = ".template",
                Filter = @"Template Files (.template)|*.template"
            };
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Template = JsonConvert.DeserializeObject<CalculationTemplate>(
                    System.IO.File.ReadAllText(openDialog.FileName));
                using (var context = new ConstructionDataContext())
                {
                    context.Database.Log = _print.PrintLog;
                    comboBoxEditBusinessFeature.EditValue = FindFile(context, Template.BusinessFeature.Id);
                    comboBoxEditConstructionValue.EditValue = FindFile(context, Template.ConstructionValue.Id);
                    comboBoxEditRiskLevel.EditValue = FindFile(context, Template.RiskLevel.Id);
                    comboBoxEditCellMapping.EditValue = FindFile(context, Template.CellMapping.Id);
                    foreach (var construction in Template.Constructions)
                    {
                        var item = cmbListConstructions.Properties.Items
                            .FirstOrDefault(w => ((File)w.Value).Id == construction.Id);
                        if (item != null)
                        {
                            item.CheckState = CheckState.Checked;
                        }
                    }
                }
            }
        }

        private File FindFile(ConstructionDataContext context, int fileId)
        {
            var file = context.Files.FirstOrDefault(f => f.Id == fileId);
            return file;

        }
    }
}