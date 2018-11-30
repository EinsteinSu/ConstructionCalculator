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
            out int existsFileId, string description, ILogPrint print = null, IShowProgress showProgress = null) where T : class, IFile
        {
            existsFileId = 0;

            var enumerable = data as T[] ?? data.ToArray();


            var type = ConvertFileType(GetName(enumerable.First()));
            print?.PrintLog("Find the existing files.");
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
            print?.PrintLog($"The file id is {id}");
            showProgress?.SetMaxValue(enumerable.Length);
            int i = 0;
            foreach (var item in enumerable)
            {
                showProgress?.SetCurrentValue(i);
                item.FileId = id;
                i++;
            }
            print?.PrintLog("Saving data to database.");
            context.SaveChanges();
            showProgress?.Done();
            return true;
        }

        public static void Save<T>(this IEnumerable<T> data, ConstructionDataContext context, ILogPrint print = null) where T : class, IFile
        {
            if (HasFile(data))
            {
                var id = GetFileId(data);
                print?.PrintLog($"The file id is {id}");
                SaveWithFileId(data, context, id);
            }
        }

        public static void SaveWithFileId<T>(this IEnumerable<T> data, ConstructionDataContext context, int fileId, ILogPrint print = null, IShowProgress showProgress = null)
            where T : class, IFile
        {
            print?.PrintLog($"The file id is {fileId}");
            showProgress?.SetMaxValue(data.Count());
            int i = 0;
            foreach (var item in data)
            {
                item.FileId = fileId;
                context.Entry(item).State = EntityState.Modified;
                showProgress?.SetCurrentValue(i);
                i++;
            }
            print?.PrintLog("Saving data to database.");
            context.SaveChanges();
            showProgress?.Done();
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

        public static object GetDataByFileType(ConstructionDataContext context, FileType type)
        {
            switch (type)
            {
                case FileType.BusinessValue:
                    return context.BusinessValues;
                case FileType.BusinessFeature:
                    return context.BusinessFeatures;
                case FileType.CellMapping:
                    return context.CellMappings;
                case FileType.Construction:
                    return context.Constructions;
                case FileType.ConstructionValue:
                    return context.ConstructionValues;
                case FileType.RiskLevel:
                    return context.RiskLevels;
            }
            return null;
        }

        public static object GetDataByFileId(ConstructionDataContext context, int fileId)
        {
            var file = context.Files.FirstOrDefault(f => f.Id == fileId);
            if (file == null)
                return null;
            switch (file.Type)
            {
                case FileType.BusinessValue:
                    return context.BusinessValues.Where(w=>w.FileId == file.Id);
                case FileType.BusinessFeature:
                    return context.BusinessFeatures.Where(w => w.FileId == file.Id);
                case FileType.CellMapping:
                    return context.CellMappings.Where(w => w.FileId == file.Id);
                case FileType.Construction:
                    return context.Constructions.Where(w => w.FileId == file.Id);
                case FileType.ConstructionValue:
                    return context.ConstructionValues.Where(w => w.FileId == file.Id);
                case FileType.RiskLevel:
                    return context.RiskLevels.Where(w => w.FileId == file.Id);
            }
            return null;
        }
    }
}