using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ConstructionCalculator.DataAccess;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace ConstructionCalculator
{
    public partial class MainForm : RibbonForm
    {
        protected ConstructionDataContext Context = new ConstructionDataContext("Construction");
        private XtraUserControl customersUserControl;
        private XtraUserControl employeesUserControl;

        public MainForm()
        {
            InitializeComponent();
            employeesUserControl = CreateUserControl("Employees");
            customersUserControl = CreateUserControl("Customers");
            //accordionControl.SelectedElement = employeesAccordionControlElement;
            DisplayFiles();
        }

        #region file operation

        private void DisplayFiles()
        {
            ((ISupportInitialize)ribbonControl).BeginInit();
            barSubItemNavigation.LinksPersistInfo.Clear();
            accordionControl.Elements.Clear();
            foreach (var typeName in Enum.GetNames(typeof(FileType)))
            {
                var group = new AccordionControlElement { Text = typeName };
                Enum.TryParse(typeName, out FileType type);
                foreach (var file in Context.Files.Where(w => w.Type == type))
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

        #endregion


        private XtraUserControl CreateUserControl(string text)
        {
            var result = new DataEditControl
            {
                Name = text.ToLower() + "UserControl",
                FileId = 4,
                Context = Context
            };
            result.Initialize();
            return result;
        }

        private void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            if (e.Element == null) return;
            var userControl = e.Element.Text == "Employees" ? employeesUserControl : customersUserControl;
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
            RecreateUserControls(e);
            SetAccordionSelectedElement(e);
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
            if (e.Document.Caption == "Employees") employeesUserControl = CreateUserControl("Employees");
            else customersUserControl = CreateUserControl("Customers");
        }
    }
}