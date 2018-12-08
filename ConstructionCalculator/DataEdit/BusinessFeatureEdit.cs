using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using DevExpress.XtraGrid;

namespace ConstructionCalculator.DataEdit
{
    public class BusinessFeatureEdit : DataEditBase<BusinessFeature>
    {
        public BusinessFeatureEdit(int fileId, ConstructionDataContext context) : base(fileId, context)
        {
        }

        protected override string EntityName => "Business Feature";

        public override void BindingData(GridControl control)
        {
            control.DataSource = null;
            Context.BusinessFeatures.Where(w => w.FileId == FileId).Load();
            control.DataSource = Context.BusinessFeatures.Local.ToBindingList();
        }

        protected override ExcelDataImportBase GetImporter(string fileName)
        {
            return new BusinesFeatureImport(fileName);
        }

        public override void Add()
        {
            var businessFeature = new BusinessFeature();
            Context.BusinessFeatures.Add(businessFeature);
        }

        public override void Remove(object data)
        {
            var item = data as BusinessFeature;
            Context.BusinessFeatures.Remove(item ?? throw new InvalidOperationException());
        }

        public override void Clean()
        {
            Context.BusinessFeatures.Local.Clear();
        }

        protected override List<BusinessFeature> GetList()
        {
            return Context.BusinessFeatures.Local.ToList();
        }

        protected override void AddItem(BusinessFeature item)
        {
            Context.BusinessFeatures.Add(item);
        }
    }
}