using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using DevExpress.XtraGrid;

namespace ConstructionCalculator.DataEdit
{
    public class ConstructionEdit : DataEditBase<Construction>
    {
        public ConstructionEdit(int fileId, ConstructionDataContext context) : base(fileId, context)
        {
        }

        protected override string EntityName => "Construction";

        public override void BindingData(GridControl control)
        {
            control.DataSource = null;
            Context.Constructions.Where(w => w.FileId == FileId).Load();
            control.DataSource = Context.Constructions.Local.ToBindingList();
        }

        protected override ExcelDataImportBase GetImporter(string fileName)
        {
            return new ConstructionImport(fileName);
        }

        public override void Add()
        {
            var item = new Construction();
            Context.Constructions.Add(item);
        }

        public override void Remove(object data)
        {
            var item = data as Construction;
            Context.Constructions.Remove(item ?? throw new InvalidOperationException());
        }

        public override void Clean()
        {
            Context.Constructions.Local.Clear();
        }

        protected override List<Construction> GetList()
        {
            return Context.Constructions.Local.ToList();
        }

        protected override void AddItem(Construction item)
        {
            Context.Constructions.Add(item);
        }
    }
}