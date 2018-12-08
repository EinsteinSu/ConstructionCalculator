using System.Collections.Generic;
using System.IO;
using ConstructionCalculator.Business.Cruds;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.Business.Utilities;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using ConstructionCalculator.DataAccess.Utilities;
using DevExpress.XtraGrid;
using File = ConstructionCalculator.DataAccess.File;

namespace ConstructionCalculator.DataEdit
{
    public abstract class DataEditBase<T> : IDataEdit where T : class, IExport, IFile, new()
    {
        protected readonly int FileId;
        protected readonly ConstructionDataContext Context;
        public DataEditBase(int fileId, ConstructionDataContext context)
        {
            FileId = fileId;
            Context = context;
        }


        public abstract void BindingData(GridControl control);
        public File File => new FileMgr(Context).GetItem(FileId);

        protected abstract string EntityName { get; }

        protected abstract ExcelDataImportBase GetImporter(string fileName);

        public abstract void Add();

        public abstract void Remove(object data);

        public abstract void Clean();

        protected abstract List<T> GetList();

        protected abstract void AddItem(T item);

        //todo: don't save the changes untill the save button clicked      
        public void Import(string fileName, ILogPrint log, IShowProgress showProgress)
        {
            var importer = ImportFactory.GetImporter(File.Type, fileName);
            importer.IgnoreSaveData = true;
            importer.Print = log;
            importer.ShowProgress = showProgress;
            importer.FileId = FileId;
            importer.Context = Context;
            importer.Import();
        }

        public void Export(string fileName, ILogPrint log, IShowProgress showProgress)
        {
            GetList().Export(fileName, EntityName, log, showProgress);
        }

        public void SaveAs(string fileName, FileType type, string description, ILogPrint log, IShowProgress showProgress)
        {
            GetList().SaveAs(Context, fileName, type, description, AddItem, log, showProgress);
        }

        public void Save(ILogPrint log)
        {
            GetList().Save(Context, log);
        }
    }
}
