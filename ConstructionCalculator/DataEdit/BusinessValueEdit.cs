using System;
using System.Data.Entity;
using System.Linq;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using DevExpress.XtraGrid;

namespace ConstructionCalculator.DataEdit
{
    public class BusinessValueEdit : DataEditBase<BusinessValue>
    {
        public BusinessValueEdit(int fileId, ConstructionDataContext context) : base(fileId, context)
        {
        }

        protected override string EntityName => "Business Value";


        public override void Add()
        {
            var item = new BusinessValue
            {
                Id = Context.BusinessValues.Count() + 1,
                FileId = FileId
            };
            Context.BusinessValues.Add(item);
        }

        public override void Remove(object data)
        {
            var item = data as BusinessValue;
            Context.BusinessValues.Remove(item ?? throw new InvalidOperationException());
        }

        public override void Clean()
        {
            Context.BusinessValues.Local.Clear();
        }


        protected override ExcelDataImportBase GetImporter(string fileName)
        {
            return new BusinessValueImport(fileName);
        }

        public override void BindingData(GridControl control)
        {
            control.DataSource = null;
            Context.BusinessValues.Where(w => w.FileId == FileId).Load();
            control.DataSource = Context.BusinessValues.Local.ToBindingList();
        }
    }
}