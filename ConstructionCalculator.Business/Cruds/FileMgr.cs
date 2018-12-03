using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.Business.Cruds
{
    public class FileMgr : CrudMgrBase<File>
    {
        public FileMgr(ConstructionDataContext context) : base(context)
        {
        }

        public override string EntityName => "File";
        protected override IEnumerable<File> GetEntries()
        {
            return Context.Files;
        }

        protected override File GetEntry(int id)
        {
            return Context.Files.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(File item)
        {
            Context.Files.Add(item);
        }

        protected override void DeleteItem(File item)
        {
            Context.Files.Remove(item);
        }
    }
}
