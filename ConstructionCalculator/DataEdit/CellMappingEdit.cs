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
    public class CellMappingEdit : DataEditBase<CellMapping>
    {
        public CellMappingEdit(int fileId, ConstructionDataContext context) : base(fileId, context)
        {
        }

        public override void BindingData(GridControl control)
        {
            control.DataSource = null;
            Context.CellMappings.Where(w => w.FileId == FileId).Load();
            control.DataSource = Context.CellMappings.Local.ToBindingList();
        }

        protected override string EntityName => "Cell Mapping";
        protected override ExcelDataImportBase GetImporter(string fileName)
        {
            return new CellMappingImport(fileName);
        }

        public override void Add()
        {
            var item = new CellMapping();
            Context.CellMappings.Add(item);
        }

        public override void Remove(object data)
        {
            var item = data as CellMapping;
            Context.CellMappings.Remove(item ?? throw new InvalidOperationException());
        }

        public override void Clean()
        {
            Context.CellMappings.Local.Clear();
        }

        protected override List<CellMapping> GetList()
        {
            return Context.CellMappings.Local.ToList();
        }

        protected override void AddItem(CellMapping item)
        {
            Context.CellMappings.Add(item);
        }
    }
}
