using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataModels;
using ConstructionCalculator.Interfaces;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EF6;

namespace ConstructionCalculator.Commons
{
    public static class UnitOfWorkSource
    {
        /// <summary>
        ///     Returns the IUnitOfWorkFactory implementation.
        /// </summary>
        public static IUnitOfWorkFactory<IConstructionCalculatorUnitOfWork> GetUnitOfWorkFactory()
        {
            return new DbUnitOfWorkFactory<IConstructionCalculatorUnitOfWork>(() =>
                new ConstructionCalculatorEntitiesUnitOfWork(() => new ConstructionDataContext()));
        }
    }
}