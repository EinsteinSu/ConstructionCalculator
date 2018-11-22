using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using DevExpress.Xpf.Bars;
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

            CreateData();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void CreateData()
        {
            ImportAndValidate("CellMapping.xlsx", stream =>
            {
                var importer = new CellMappingImport(stream);
                importer.Import();
                var data = Context.CellMappings;
                var id = AddFile();
                data.SaveWithFileId(Context, id);
                GridControl.ItemsSource = data.ToList();
            });
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

        public virtual void Cleanup()
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

        private void biSave_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Saving...");
        }

        private int AddFile()
        {
            var file = new File
            {
                FileName = "aaa",
                Type = FileType.CellMapping,
                Description = "description"
            };
            return file.Add(Context);

        }
        private void BiSave_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var list = GridControl.ItemsSource as List<CellMapping>;
            list.Save(Context);
        }
    }}