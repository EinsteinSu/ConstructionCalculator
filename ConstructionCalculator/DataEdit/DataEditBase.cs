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
        protected File File;
        public DataEditBase(int fileId, ConstructionDataContext context)
        {
            FileId = fileId;
            Context = context;
            File = new FileMgr(context).GetItem(fileId);
            if (File == null)
            {
                throw new FileNotFoundException();
            }
        }


        public abstract void BindingData(GridControl control);

        protected abstract string EntityName { get; }

        protected abstract ExcelDataImportBase GetImporter(string fileName);

        public abstract void Add();

        public abstract void Remove(object data);

        //todo: don't save the changes untill the save button clicked      
        public void Import(string fileName, ILogPrint log, IShowProgress showProgress)
        {
            var importer = ImportFactory.GetImporter(File.Type, fileName);
            importer.Print = log;
            importer.ShowProgress = showProgress;
            importer.FileId = FileId;
            importer.Import();
        }

        public void Export(object list, string fileName, ILogPrint log, IShowProgress showProgress)
        {
            var data = list as List<T>;
            data.Export(fileName, EntityName, log, showProgress);
        }

        public void SaveAs(object list, string fileName, string description, out int existFileId, ILogPrint log, IShowProgress showProgress)
        {
            var data = list as List<T>;
            data.SaveAs(Context, fileName, out existFileId, description, log, showProgress);
        }

        public void Save(object list, ILogPrint log)
        {
            var data = list as List<T>;
            data.Save(Context, log);
        }
    }
}
