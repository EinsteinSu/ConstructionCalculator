using System;
using System.Collections.Generic;
using System.Data.Entity;
using ConstructionCalculator.DataAccess;

namespace ConstructionCalculator.Business.Cruds
{
    public interface ICrudMgr<T>
    {
        IEnumerable<T> GetItems();

        T GetItem(int id);

        void Add(T item);

        void Update(T item);

        void Delete(int id);
    }

    public abstract class CrudMgrBase<T> : ICrudMgr<T>, IDisposable where T : class
    {
        protected readonly ConstructionDataContext Context;

        public bool SaveChangesImmediately { get; set; }

        public CrudMgrBase(ConstructionDataContext context)
        {
#if DEBUG
            Context = context;
#else
       var licence = new License("ssu.lic");
            if (!licence.Validate())
            {
                //todo: read the documentation of how to use the license exception.
                throw new LicenseException(typeof(int), this, "You have no license to visit this application.");
            }     
#endif
        }

        public abstract string EntityName { get; }

        public IEnumerable<T> GetItems()
        {
            try
            {
                return GetEntries();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("get entries of {0} failed, {1}", EntityName, exception.Message));
            }
        }

        public T GetItem(int id)
        {
            try
            {
                return GetEntry(id);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("get entry of {0} failed, {1}", EntityName, exception.Message));
            }
        }

        public void Add(T item)
        {
            try
            {
                AddItem(item);
                if (SaveChangesImmediately)
                    Context.SaveChanges();
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                    throw new Exception($"add {EntityName} failed, {exception.InnerException.Message}");
            }
        }

        public void Update(T item)
        {
            try
            {
                UpdateItem(item);
                if (SaveChangesImmediately)
                    Context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception($"update {EntityName} failed, {exception.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var item = GetEntry(id);
                if (item == null)
                    throw new KeyNotFoundException($"Could not found id {id} in {EntityName}");
                DeleteItem(item);
                if (SaveChangesImmediately)
                {
                    Context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"delete {EntityName} failed, {exception.Message}");
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        protected abstract IEnumerable<T> GetEntries();

        protected abstract T GetEntry(int id);

        protected abstract void AddItem(T item);

        protected virtual void UpdateItem(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        protected abstract void DeleteItem(T item);
    }
}