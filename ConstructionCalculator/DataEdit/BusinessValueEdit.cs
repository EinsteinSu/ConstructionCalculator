using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConstructionCalculator.Business.Cruds;
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


        protected override ExcelDataImportBase GetImporter(string fileName)
        {
            return new BusinessValueImport(fileName);
        }

        public override void BindingData(GridControl control)
        {
            Context.BusinessValues.Where(w => w.FileId == FileId).Load();
            control.DataSource = Context.BusinessValues.Local.ToBindingList();
        }

        protected override string EntityName => "Business Value";
    }
}