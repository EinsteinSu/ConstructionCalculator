using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using ConstructionCalculator.DataEdit;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace ConstructionCalculator
{
    public partial class MainForm : RibbonForm, ILogPrint, IShowProgress
    {
        public MainForm()
        {
            InitializeComponent();
            //employeesUserControl = CreateUserControl("Employees");
            //customersUserControl = CreateUserControl("Customers");
            //accordionControl.SelectedElement = employeesAccordionControlElement;
            if (!DesignMode)
                DisplayFiles();
        }

        #region file operation

        private void DisplayFiles()
        {
            using (var context = new ConstructionDataContext())
            {
                ((ISupportInitialize)ribbonControl).BeginInit();
                barSubItemNavigation.LinksPersistInfo.Clear();
                accordionControl.Elements.Clear();
                foreach (var typeName in Enum.GetNames(typeof(FileType)))
                {
                    var group = new AccordionControlElement { Text = typeName };
                    Enum.TryParse(typeName, out FileType type);
                    foreach (var file in context.Files.Where(w => w.Type == type))
                    {
                        #region display file in the group of parameter types

                        var item = new AccordionControlElement
                        {
                            Style = ElementStyle.Item,
                            Name = file.FileName,
                            Text = file.FileName,
                            Tag = file
                        };
                        group.Elements.Add(item);
                        item.Click += Item_Click;
                        #endregion

                        #region add to navigation list

                        var barItem = new BarButtonItem
                        {
                            Caption = file.FileName,
                            Tag = file
                        };
                        ribbonControl.Items.Add(barItem);
                        barSubItemNavigation.LinksPersistInfo.Add(new LinkPersistInfo(barItem));
                        #endregion
                    }

                    accordionControl.Elements.Add(group);
                }

                ((ISupportInitialize)ribbonControl).EndInit();
            }

        }

        Dictionary<string, DataEditControl> controls = new Dictionary<string, DataEditControl>();
        private void Item_Click(object sender, EventArgs e)
        {
            if (sender is AccordionControlElement item)
            {
                if (item.Tag is File file && !controls.ContainsKey(file.FileName))
                {
                    var control = CreateUserControl(file.FileName);
                    var dataEdit = DataEditFactory.GetDataEdit(file, control.Context);
                    control.DataEdit = dataEdit;
                    dataEdit.BindingData(control.GridControl);
                    controls.Add(file.FileName, control);
                }
            }
        }

        #endregion


        private DataEditControl CreateUserControl(string text)
        {
            var result = new DataEditControl
            {
                Name = text.ToLower() + "UserControl",
                Text = text,
                Context = new ConstructionDataContext()
            };
            result.Context.Database.Log = PrintLog;
            return result;
        }

        private void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            if (e.Element == null)
                return;
            var userControl = controls[e.Element.Text];
            tabbedView.AddDocument(userControl);
            tabbedView.ActivateDocument(userControl);
        }

        private void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            var barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            accordionControl.SelectedElement = mainAccordionGroup.Elements[barItemIndex];
        }

        private void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            //todo: checking the unchanged data then reminde
        }

        private void SetAccordionSelectedElement(DocumentEventArgs e)
        {
            if (tabbedView.Documents.Count != 0)
                if (e.Document.Caption == "Employees")
                    accordionControl.SelectedElement = customersAccordionControlElement;
                else
                    accordionControl.SelectedElement = employeesAccordionControlElement;
            else
                accordionControl.SelectedElement = null;
        }

        private void RecreateUserControls(DocumentEventArgs e)
        {

        }

        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
                control.DataEdit.Add();
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
                control.Context.SaveChanges();
        }

        private void barButtonItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    DefaultExt = ".xlsx",
                    Filter = @"Excel Files (.xlsx)|*.xlsx"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    control.DataEdit.Import(dialog.FileName, this, this);
                }
            }
        }

        #region Print log and show progress
        public void PrintLog(string logging)
        {
            rtbOutput.AppendText(logging);
            rtbOutput.ScrollToCaret();
            Application.DoEvents();
        }

        public void SetMaxValue(int maxValue)
        {

        }

        public void SetCurrentValue(int value)
        {

        }

        public void Done()
        {

        }
        #endregion

        private void barButtonItemClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                control.DataEdit.Clean();
            }
        }
    }
}