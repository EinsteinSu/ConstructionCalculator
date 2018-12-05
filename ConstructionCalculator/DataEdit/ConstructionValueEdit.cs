using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using DevExpress.XtraGrid;

namespace ConstructionCalculator.DataEdit
{
    public class ConstructionValueEdit : DataEditBase<ConstructionValue>
    {
        public ConstructionValueEdit(int fileId, ConstructionDataContext context) : base(fileId, context)
        {
        }

        public override void BindingData(GridControl control)
        {
            control.DataSource = null;
            Context.ConstructionValues.Where(w => w.FileId == FileId).Load();
            control.DataSource = Context.ConstructionValues.Local.ToBindingList();
        }

        protected override string EntityName => "Construction Value";
        protected override ExcelDataImportBase GetImporter(string fileName)
        {
            return new ConstructionValueImport(fileName);
        }

        public override void Add()
        {
            var item = new ConstructionValue();
            Context.ConstructionValues.Add(item);
        }

        public override void Remove(object data)
        {
            var item = data as ConstructionValue;
            Context.ConstructionValues.Remove(item ?? throw new InvalidOperationException());
        }

        public override void Clean()
        {
            Context.ConstructionValues.Local.Clear();
        }

        protected override List<ConstructionValue> GetList()
        {
            return Context.ConstructionValues.ToList();
        }
    }
}
