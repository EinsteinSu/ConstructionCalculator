using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess.Utilities
{
    public static class FileHelper
    {
        public static bool SaveAs<T>(this IEnumerable<T> data, ConstructionDataContext context, string filename,
            out int existsFileId, string description) where T : class, IFile
        {
            existsFileId = 0;

            var enumerable = data as T[] ?? data.ToArray();


            var type = ConvertFileType(GetName(enumerable.First()));
            var file = File.Select(context, filename, type);
            if (file != null)
            {
                existsFileId = file.Id;
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

        public static void Save<T>(this IEnumerable<T> data, ConstructionDataContext context) where T : class, IFile
        {
            if (HasFile(data))
            {
                var id = GetFileId(data);
                SaveWithFileId(data, context, id);
            }
        }

        public static void SaveWithFileId<T>(this IEnumerable<T> data, ConstructionDataContext context, int fileId)
            where T : class, IFile
        {
            foreach (var item in data)
            {
                item.FileId = fileId;
                context.Entry(item).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public static bool HasFile<T>(this IEnumerable<T> data) where T : IFile
        {
            return data.Any(a => a.FileId.HasValue);
        }

        public static int GetFileId<T>(this IEnumerable<T> data) where T : IFile
        {
            if (HasFile(data)) return data.FirstOrDefault().FileId.Value;
            return 0;
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