using System.Collections.Generic;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using DevExpress.XtraGrid;

namespace ConstructionCalculator.DataEdit
{
    public interface IDataEdit
    {
        void Add();

        void Remove(object data);

        void Clean();

        void Import(string fileName, ILogPrint log, IShowProgress showProgress);

        void Export(string fileName, ILogPrint log, IShowProgress showProgress);
        void SaveAs(string fileName,FileType type, string description, ILogPrint log,
            IShowProgress showProgress);

        void Save(ILogPrint log);

        void BindingData(GridControl control);

        File File { get; }
    }
}