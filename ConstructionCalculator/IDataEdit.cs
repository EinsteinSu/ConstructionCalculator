using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using ConstructionCalculator.DataAccess.Utilities;
using DevExpress.XtraGrid;

namespace ConstructionCalculator
{
    public abstract class DataEditBase<T> where T : class, ICreate<T>, IExport, IFile, new()
    {
        private readonly int _fileId;
        private readonly ConstructionDataContext _context;

        public DataEditBase(int fileId, ConstructionDataContext context)
        {
            _fileId = fileId;
            _context = context;
        }

        public abstract IList<T> List { get; }

        protected abstract ExcelDataImportBase Importer { get; }

        public void Add()
        {
            var item = new T().CreateItem();
            List.Add(item);
        }

        public void Remove(object data)
        {
            var item = data as T;
            List.Remove(item);
        }

        public void Import(string fileName)
        {
            Importer.Import();
        }

        public void SaveAs(string fileName, string description, out int existFileId, ILogPrint log, IShowProgress showProgress)
        {
            List.SaveAs(_context, fileName, out existFileId, description, log, showProgress);
        }

        public void Save(ILogPrint log)
        {
            List.Save(_context, log);
        }
    }
}
