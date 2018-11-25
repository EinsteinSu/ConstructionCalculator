using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.Business.Utilities;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Utilities;
using ConstructionCalculator.UI.Test.Common;
using DevExpress.Xpf.Bars;
using Microsoft.Win32;
using File = ConstructionCalculator.DataAccess.File;

namespace ConstructionCalculator.UI.Test
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private const string Prefix = "ConstructionCalculator.UI.Test.TestResource.";
        protected ConstructionDataContext Context = new ConstructionDataContext("Construction");

        public MainWindow()
        {
            InitializeComponent();
            Closed += MainWindow_Closed;
            BindingData();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BindingData()
        {
            var data = Context.CellMappings;
            GridControl.ItemsSource = data.ToList();

        }

        protected void ImportAndValidate(string fileName, Action<Stream> validation)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream =
                assembly.GetManifestResourceStream(Prefix + fileName)
            )
            {
                validation?.Invoke(stream);
            }
        }

        public void Cleanup()
        {
            Context.Database.ExecuteSqlCommand("Delete From Constructions");
            Context.Database.ExecuteSqlCommand("Delete From BusinessFeatures");
            Context.Database.ExecuteSqlCommand("Delete From BusinessValues");
            Context.Database.ExecuteSqlCommand("Delete From ConstructionValues");
            Context.Database.ExecuteSqlCommand("Delete From CellMappings");
            Context.Database.ExecuteSqlCommand("Delete From RiskLevels");
            Context.Database.ExecuteSqlCommand("Delete From Files");
            Context.Dispose();
        }

        private void biSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Saving...");
        }

        private int AddFile(string fileName)
        {
            var file = new File
            {
                FileName = fileName,
                Type = FileType.CellMapping,
                Description = "description"
            };
            return file.Add(Context);
        }

        private void BiSave_OnItemClick(object sender, ItemClickEventArgs e)
        {

            var list = GridControl.ItemsSource as List<CellMapping>;
            if (!list.HasFile())
            {
                var window = new FileNameInputWindow();
                if (window.GetShowDialog())
                {
                    list.SaveAs(Context, window.FileName, out var id, "");
                }
            }
            else
            {
                list.Save(Context);
            }
        }
        private void BiExport_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                FileName = "Document",
                DefaultExt = ".xlsx",
                Filter = "Excel Files (.xlsx)|*.xlsx"
            };
            if (dlg.ShowDialog().Value)
            {
                var fileName = dlg.FileName;
                var list = GridControl.ItemsSource as List<CellMapping>;
                list.Export(fileName, "Test");
            }
        }

        private void BiImport_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files (.xlsx)|*.xlsx"
            };
            if (ofd.ShowDialog().Value)
            {
                var fileName = ofd.FileName;
                var importer = new CellMappingImport(fileName);
                var includeHeader = MessageBox.Show("Include header?", "Include header", MessageBoxButton.OKCancel) ==
                                    MessageBoxResult.OK;
                importer.IncludeHeader = includeHeader;
                importer.Import();
                var data = Context.CellMappings;
                GridControl.ItemsSource = data.ToList();
                processBar.EditValue = 100;
            }
        }
        //save as
        private void BarItem_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var window = new FileNameInputWindow();
            if (window.GetShowDialog())
            {
                var fileName = window.FileName;
                var list = GridControl.ItemsSource as List<CellMapping>;
                if (!list.SaveAs(Context, fileName, out var fileId, ""))
                {
                    if (MessageBox.Show("The file has exists!", "File exists", MessageBoxButton.OKCancel) ==
                        MessageBoxResult.OK)
                    {
                        list.SaveWithFileId(Context, fileId);
                    }
                }

            }
        }

        private void AddButton_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var cm = new CellMapping();
            cm.ColumnName = "1";
            cm.ColumnExcelNumber = "A1";
            var list = GridControl.ItemsSource as List<CellMapping>;
            list.Add(cm);
        }

        private void RemoveButton_OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (GridControl.SelectedItem is CellMapping item)
            {
                var list = GridControl.ItemsSource as List<CellMapping>;
                list.Remove(item);
            }
        }
    }
}