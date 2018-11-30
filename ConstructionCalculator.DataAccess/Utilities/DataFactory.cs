using System;
using System.IO;
using System.Linq;
using ConstructionCalculator.DataAccess.Interfaces;

namespace ConstructionCalculator.DataAccess.Utilities
{
    //todo: unit test
    public class DataFactory
    {
        private readonly ConstructionDataContext _context;
        private readonly int _fileId;
        private readonly FileType _type;

        public DataFactory(int fileId, ConstructionDataContext context)
        {
            _context = context;
            _fileId = fileId;
            var file = context.Files.FirstOrDefault(f => f.Id == fileId);
            if (file == null) throw new FileNotFoundException();

            _type = file.Type;
        }

        public object GetList()
        {
            switch (_type)
            {
                case FileType.BusinessValue:
                    return _context.BusinessValues.Where(w => w.FileId == _fileId).ToList();
                case FileType.BusinessFeature:
                    return _context.BusinessFeatures.Where(w => w.FileId == _fileId).ToList();
                case FileType.CellMapping:
                    return _context.CellMappings.Where(w => w.FileId == _fileId).ToList();
                case FileType.Construction:
                    return _context.Constructions.Where(w => w.FileId == _fileId);
                case FileType.ConstructionValue:
                    return _context.ConstructionValues.Where(w => w.FileId == _fileId).ToList();
                case FileType.RiskLevel:
                    return _context.RiskLevels.Where(w => w.FileId == _fileId).ToList();
            }

            return null;
        }

        public void AddItem(int fileId)
        {
            if (GetNewItem() is IFile item)
            {
                item.FileId = fileId;
                switch (_type)
                {
                    case FileType.BusinessValue:
                        _context.BusinessValues.Add(item as BusinessValue ?? throw new InvalidOperationException());
                        break;
                    case FileType.BusinessFeature:
                        _context.BusinessFeatures.Add(item as BusinessFeature ?? throw new InvalidOperationException());
                        break;
                    case FileType.CellMapping:
                        _context.CellMappings.Add(item as CellMapping ?? throw new InvalidOperationException());
                        break;
                    case FileType.Construction:
                        _context.Constructions.Add(item as Construction ?? throw new InvalidOperationException());
                        break;
                    case FileType.ConstructionValue:
                        _context.ConstructionValues.Add(item as ConstructionValue ??
                                                        throw new InvalidOperationException());
                        break;
                    case FileType.RiskLevel:
                        _context.RiskLevels.Add(item as RiskLevel ?? throw new InvalidOperationException());
                        break;
                }
            }
        }

        public object GetNewItem()
        {
            switch (_type)
            {
                case FileType.BusinessValue:
                    return new BusinessValue().CreateItem();
                case FileType.BusinessFeature:
                    return new BusinessFeature().CreateItem();
                case FileType.CellMapping:
                    return new CellMapping().CreateItem();
                case FileType.Construction:
                    return new Construction().CreateItem();
                case FileType.ConstructionValue:
                    return new ConstructionValue().CreateItem();
                case FileType.RiskLevel:
                    return new RiskLevel().CreateItem();
            }

            return null;
        }
    }
}