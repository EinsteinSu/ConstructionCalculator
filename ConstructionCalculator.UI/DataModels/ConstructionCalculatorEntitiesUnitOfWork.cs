using System;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.Interfaces;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EF6;

namespace ConstructionCalculator.DataModels
{
    public class ConstructionCalculatorEntitiesUnitOfWork : DbUnitOfWork<ConstructionDataContext>,
        IConstructionCalculatorUnitOfWork
    {
        public ConstructionCalculatorEntitiesUnitOfWork(Func<ConstructionDataContext> contextFactory) : base(
            contextFactory)
        {
        }

        public IRepository<File, int> Files
        {
            get
            {
                return GetRepository(x => x.Set<File>(), x => x.Id);
            }
        }

        public IRepository<BusinessValue, int> BusinessValues { get; }
        public IRepository<BusinessFeature, int> BusinessFeatures { get; }
    }
}