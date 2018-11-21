using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionCalculator.DataAccess.Interfaces
{
    public interface IFile
    {
        int? FileId { get; set; }
    }

    public static class IFileHelper
    {
        //todo: to be tested
        public static void SaveAs<T>(List<T> data, string filename) where T : IFile
        {
            //todo: check whether an entry exists in file table, if yes, return false and out a notification
            //todo: insert an entry after checking and get the id
            int id = 0;
            foreach (var item in data)
            {
                item.FileId = id;
            }
            //todo: store it in database.

        }
    }
}
