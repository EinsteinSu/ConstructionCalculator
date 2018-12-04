using System.Collections.Generic;
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

        void Export(object list, string fileName, ILogPrint log, IShowProgress showProgress);

        void SaveAs(object list, string fileName, string description, out int existFileId, ILogPrint log,
            IShowProgress showProgress);

        void Save(object list, ILogPrint log);

        void BindingData(GridControl control);
    }
}