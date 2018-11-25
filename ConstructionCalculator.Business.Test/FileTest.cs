using System;
using System.Linq;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class FileTest : TestBase
    {
        private const string FileName = "test file";
        private const string Description = "this is a description";

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

        [TestMethod]
        public void FileAdd()
        {
            var id = AddFile();
            Assert.IsTrue(id > 0);
            Console.WriteLine(id);
        }

        private int AddFile()
        {
            var file = new File
            {
                FileName = FileName,
                Type = FileType.CellMapping,
                Description = Description
            };
            return file.Add(Context);
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
        public void HasValue()
        {
            ImportAndValidate("CellMapping.xlsx", stream =>
            {
                var importer = new CellMappingImport(stream);
                importer.Import();
                var result = Context.CellMappings.HasFile();
                Assert.IsFalse(result);
                var id = AddFile();
                Context.CellMappings.SaveWithFileId(Context, id);
                result = Context.CellMappings.HasFile();
                Assert.IsTrue(result);
            });
        }

        [TestMethod]
        public void GetFileId()
        {
            ImportAndValidate("CellMapping.xlsx", stream =>
            {
                var importer = new CellMappingImport(stream);
                importer.Import();
                var id = AddFile();
                Context.CellMappings.SaveWithFileId(Context, id);
                var result = Context.CellMappings.GetFileId();
                Assert.AreEqual(id, result);
            });
        }

        [TestMethod]
        public void Save()
        {
            ImportAndValidate("CellMapping.xlsx", stream =>
            {
                var importer = new CellMappingImport(stream);
                importer.Import();
                var id = AddFile();
                Context.CellMappings.SaveWithFileId(Context, id);
                var item = Context.CellMappings.FirstOrDefault();
                Assert.IsNotNull(item);
                item.ColumnExcelNumber = "A%";
                Context.CellMappings.Save(Context);
                var context = new ConstructionDataContext("Construction");
                var actual = context.CellMappings.FirstOrDefault();
                Assert.IsNotNull(actual);
                Assert.AreEqual(actual.ColumnExcelNumber, item.ColumnExcelNumber);
            });
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
                Assert.IsTrue(report == 0);
                var item = Context.CellMappings.First();
                Assert.IsNotNull(item);
                Assert.IsTrue(item.FileId > 0);
                result = list.SaveAs(Context, FileName, out report, Description);
                Assert.IsFalse(result);
                Assert.IsTrue(report > 0);
                Console.WriteLine(report);
            });
        }
    }
}