using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.Business.Cruds
{
    public class BusinessValueMgr : CrudMgrBase<BusinessValue>, IFileRetrieve<BusinessValue>
    {
        public BusinessValueMgr(ConstructionDataContext context) : base(context)
        {
        }

        public override string EntityName => "Business Value";

        protected override IEnumerable<BusinessValue> GetEntries()
        {
            return Context.BusinessValues;
        }

        protected override BusinessValue GetEntry(int id)
        {
            return Context.BusinessValues.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(BusinessValue item)
        {
            Context.BusinessValues.Add(item);
        }

        protected override void DeleteItem(BusinessValue item)
        {
            Context.BusinessValues.Remove(item);
        }

        public IEnumerable<BusinessValue> GetEntries(int fileId)
        {
            return Context.BusinessValues.Where(w => w.FileId == fileId).ToList();
        }
    }
}
