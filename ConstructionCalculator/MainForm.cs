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
using DevExpress.XtraGrid.Views.Grid;

namespace ConstructionCalculator
{
    public partial class MainForm : RibbonForm, ILogPrint, IShowProgress
    {
        public MainForm()
        {
            InitializeComponent();
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
                if (item.Tag is File file)
                {
                    DataEditControl control;
                    if (!controls.ContainsKey(file.FileName))
                    {
                        control = CreateUserControl(file.FileName);
                        var dataEdit = DataEditFactory.GetDataEdit(file, control.Context);
                        control.DataEdit = dataEdit;
                        dataEdit.BindingData(control.GridControl);
                        controls.Add(file.FileName, control);
                    }
                    else
                    {
                        control = controls[file.FileName];
                    }
                    tabbedView.AddDocument(control);
                    tabbedView.ActivateDocument(control);
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

        #region navigation and tabbed view actions

        private void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            //if (e.Element == null)
            //    return;
            //var userControl = controls[e.Element.Text];
            //tabbedView.AddDocument(userControl);
            //tabbedView.ActivateDocument(userControl);
        }

        private void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            var barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            accordionControl.SelectedElement = mainAccordionGroup.Elements[barItemIndex];
        }

        private void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            //todo: checking the unchanged data then reminde
            tabbedView.RemoveDocument(controls[e.Document.Caption]);
            controls.Remove(e.Document.Caption);
        }


        #endregion

        #region Parameters edit actions
        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control != null &&
                tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                try
                {
                    control.DataEdit.Add();
                }
                catch (Exception exception)
                {
                    ShowException(exception, $"Add entry for {control.Text} failed.");
                }

            }
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                try
                {
                    control.Context.SaveChanges();
                }
                catch (Exception exception)
                {
                    ShowException(exception, $"Save changes for {control.Text} failed.");
                }

            }
        }


        private void barButtonItemSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                //todo: implement
                //control.DataEdit.SaveAs();
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                try
                {
                    control.DataEdit.Remove(control.FocusedRow);
                }
                catch (Exception exception)
                {
                    ShowException(exception, $"Remove file for {control.Text} failed.");
                }

            }
        }
        #endregion




        #region Print log and show progress
        public void PrintLog(string logging)
        {
            rtbOutput.AppendText(logging + Environment.NewLine);
            barStaticItemLog.Caption = logging;
            rtbOutput.ScrollToCaret();
            Application.DoEvents();
        }

        public void SetMaxValue(int maxValue)
        {
            barEditItemProgress.Visibility = BarItemVisibility.Always;
            progressBar.Maximum = maxValue;
        }

        public void SetCurrentValue(int value)
        {
            barEditItemProgress.EditValue = value;
            Application.DoEvents();
        }

        public void Done()
        {
            barEditItemProgress.EditValue = 0;
            barEditItemProgress.Visibility = BarItemVisibility.Never;
        }
        #endregion

        private void barButtonItemClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                control.DataEdit.Clean();
            }
        }

        #region file operations
        private void barButtonItemAddFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            var addForm = new FileEditWindow();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                using (var context = new ConstructionDataContext())
                {
                    context.Database.Log = PrintLog;
                    File file = new File();
                    file.FileName = addForm.FileName;
                    file.Type = addForm.FileType;
                    if (!file.Exists(context))
                    {
                        try
                        {
                            file.Add(context);
                            DisplayFiles();

                        }
                        catch (Exception exception)
                        {
                            ShowException(exception, "Add file failed.");
                        }

                    }
                    else
                    {
                        MessageBox.Show(
                            $"The type of file has existed, please try another name. {file.Type}|{file.FileName}");
                    }
                }
            }
        }

        private void barButtonItemRemoveFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = accordionControl.SelectedElement;
            if (item != null)
            {
                var file = item.Tag as File;
                if (file == null)
                    return;
                using (var context = new ConstructionDataContext())
                {
                    try
                    {
                        context.Database.Log = PrintLog;
                        file.Delete(context);
                    }
                    catch (Exception exception)
                    {
                        ShowException(exception, "Remove file failed.");
                    }

                }
                tabbedView.RemoveDocument(controls[file.FileName]);
                controls.Remove(file.FileName);
                DisplayFiles();
            }
        }
        #endregion

        #region Import and export

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
                    try
                    {
                        control.DataEdit.Import(dialog.FileName, this, this);
                    }
                    catch (Exception exception)
                    {
                        ShowException(exception, "Import failed.");
                    }

                }
            }
        }

        private void barButtonItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabbedView.ActiveDocument.Control is DataEditControl control)
            {
                var dialog = new SaveFileDialog
                {
                    FileName = control.Text,
                    DefaultExt = ".xlsx",
                    Filter = @"Excel Files (.xlsx)|*.xlsx"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        control.DataEdit.Export(dialog.FileName, this, this);
                    }
                    catch (Exception exception)
                    {
                        ShowException(exception, "Export failed.");
                    }

                }
            }
        }

        #endregion


        private void barButtonItemCalculate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dialog = new CalculateTemplateWindow(this);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //todo: calculate

            }
        }

        private void ShowException(Exception exception, string message)
        {
            MessageBox.Show($"message, {exception.Message}", "Error");
            PrintLog($"Error: {exception.Message}");
        }

    }
}