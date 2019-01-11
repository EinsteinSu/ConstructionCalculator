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
    public class RiskLevelEdit : DataEditBase<RiskLevel>
    {
        public RiskLevelEdit(int fileId, ConstructionDataContext context) : base(fileId, context)
        {
        }

        public override void BindingData(GridControl control)
        {
            control.DataSource = null;
            Context.RiskLevels.Where(w => w.FileId == FileId).Load();
            control.DataSource = Context.RiskLevels.Local.ToBindingList();
        }

        protected override string EntityName => "Risk Level";

        protected override ExcelDataImportBase GetImporter(string fileName)
        {
            return new RiskLevelImport(fileName);
        }

        public override void Add()
        {
            var item = new RiskLevel { FileId = FileId };
            Context.RiskLevels.Add(item);
        }

        public override void Remove(object data)
        {
            var item = data as RiskLevel;
            Context.RiskLevels.Remove(item ?? throw new InvalidOperationException());
        }

        public override void Clean()
        {
            Context.RiskLevels.Local.Clear();
        }

        protected override List<RiskLevel> GetList()
        {
            return Context.RiskLevels.Local.ToList();
        }

        protected override void AddItem(RiskLevel item)
        {
            Context.RiskLevels.Add(item);
        }
    }
}
