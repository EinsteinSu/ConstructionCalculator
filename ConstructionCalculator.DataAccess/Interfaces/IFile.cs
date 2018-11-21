using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionCalculator.DataAccess.Interfaces
{
    public interface IFile
    {
        int? FileId { get; set; }
    }

    public static class FileHelper
    {
        public static bool SaveAs<T>(this IEnumerable<T> data, ConstructionDataContext context, string filename,
            out string report, string description) where T : class, IFile
        {
            report = string.Empty;

            var enumerable = data as T[] ?? data.ToArray();
            if (!enumerable.Any())
            {
                report = "no data needs to be saved";
                return false;
            }

            var type = ConvertFileType(GetName(enumerable.First()));
            var file = File.Select(context, filename, type);
            if (file != null)
            {
                report = "File has already exists";
                return false;
            }

            file = new File
            {
                FileName = filename,
                Description = description,
                Type = type
            };
            var id = file.Add(context);
            foreach (var item in enumerable) item.FileId = id;
            context.SaveChanges();
            return true;
        }


        public static string GetName<T>(T data) where T : class, IFile
        {
            return typeof(T).Name;
        }

        public static FileType ConvertFileType(string type)
        {
            Enum.TryParse(type, true, out FileType item);
            return item;
        }

        public static bool Exists(ConstructionDataContext context, string fileName, string type)
        {
            return File.Select(context, fileName, ConvertFileType(type)) != null;
        }
    }
}