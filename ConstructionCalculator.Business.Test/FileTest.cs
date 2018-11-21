using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class FileTest : TestBase
    {
        [TestMethod]
        public void GetName()
        {
            const string expected = "CellMapping";
            var result = FileHelper.GetName(new CellMapping());
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void ConvertFileType()
        {
            var item = FileHelper.GetName(new CellMapping());
            const FileType expected = FileType.CellMapping;
            var result = FileHelper.ConvertFileType(item);
            Assert.AreEqual(result, expected);
        }

        private const string FileName = "test file";
        private const string Description = "this is a description";
        [TestMethod]
        public void FileAdd()
        {
            var file = new File
            {
                FileName = FileName,
                Type = FileType.CellMapping,
                Description = Description
            };
            var id = file.Add(Context);
            Assert.IsTrue(id > 0);
            Console.WriteLine(id);
        }

        [TestMethod]
        public void FileSelect()
        {
            FileAdd();
            var result = File.Select(Context, FileName, FileType.CellMapping);
            Console.WriteLine(result.Id);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void SaveAs()
        {
            ImportAndValidate("CellMapping.xlsx", stream =>
            {
                var importer = new CellMappingImport(stream);
                importer.Import();
                var list = Context.CellMappings;
                var result = list.SaveAs(Context, FileName, out var report, Description);
                Assert.IsTrue(result);
                Assert.IsTrue(string.IsNullOrEmpty(report));
                var item = Context.CellMappings.First();
                Assert.IsNotNull(item);
                Assert.IsTrue(item.FileId > 0);
                result = list.SaveAs(Context, FileName, out report, Description);
                Assert.IsFalse(result);
                Assert.IsTrue(!string.IsNullOrEmpty(report));
                Console.WriteLine(report);
            });
        }
    }
}
