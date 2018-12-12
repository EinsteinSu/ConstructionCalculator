using System;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;

namespace ConstructionCalculator.Commons
{
    public abstract class
        SingleObjectViewModel<TEntity, TPrimaryKey, TUnitOfWork> : SingleObjectViewModelBase<TEntity, TPrimaryKey,
            TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     Initializes a new instance of the SingleObjectViewModel class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create the unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        /// <param name="getEntityDisplayNameFunc">
        ///     An optional parameter that provides a function to obtain the display text for a
        ///     given entity. If ommited, the primary key value is used as a display text.
        /// </param>
        protected SingleObjectViewModel(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc,
            Func<TEntity, object> getEntityDisplayNameFunc = null)
            : base(unitOfWorkFactory, getRepositoryFunc, getEntityDisplayNameFunc)
        {
        }
    }
}