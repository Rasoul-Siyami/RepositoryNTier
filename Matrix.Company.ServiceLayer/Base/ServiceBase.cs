using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;

namespace Matrix.Company.ServiceLayer.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _UOW;
        protected readonly IDbSet<TEntity> _TEntity;

        public ServiceBase(IUnitOfWork uow)
        {
            _UOW = uow;
            _TEntity = _UOW.Set<TEntity>();
        }

        public int Count
        {
            get
            {
                return _TEntity.Count();
            }
        }

        public TEntity Add(TEntity data)
        {
            return _TEntity.Add(data);
        }

        public void Add(IList<TEntity> data)
        {
            foreach (var item in data)
            {
                Add(item);
            };
        }

        public void Add(ICollection<TEntity> data)
        {
            foreach (var item in data)
            {
                Add(item);
            };
        }

        public void Delete(TEntity TEntity)
        {
            _TEntity.Remove(TEntity);
        }

        public void Delete(object key)
        {
            Delete(Find(key));
        }

        public void Delete(Func<TEntity, bool> expression)
        {
            _TEntity.Remove(_TEntity.Where(expression).FirstOrDefault());
        }

        public void Edit(TEntity TEntity)
        {
            _UOW.Entry(TEntity).State = EntityState.Modified;
        }

        public void Edit(int id, TEntity TEntity)
        {
            _UOW.Entry(TEntity).State = EntityState.Modified;
        }

        public void Edit(string id, TEntity TEntity)
        {
            _UOW.Entry(TEntity).State = EntityState.Modified;
        }

        public TEntity Find(object key)
        {
            return _TEntity.Find(key);
        }

        public TEntity Find(TEntity data)
        {
            return _TEntity.FirstOrDefault(x => x == data);
        }

        public TEntity Find(Func<TEntity, bool> expression)
        {
            return _TEntity.Where(expression).FirstOrDefault();
        }

        public IList<TEntity> All()
        {
            return _TEntity.AsNoTracking().ToList();
        }

        public IList<TEntity> All(Func<TEntity, bool> expression, bool list = true)
        {
            return _TEntity.Where(expression).ToList();
        }

        public IList<TEntity> AllIncluding(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _TEntity;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public ObservableCollection<TEntity> GetSyncedListInclude(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var includeProperty in includeProperties)
            {
                _TEntity.Include(includeProperty);
            }
            _TEntity.ToList();
            _TEntity.Load();
            return _TEntity.Local;
        }

        public ObservableCollection<TEntity> GetSyncedList(int count = 1000)
        {
            _TEntity.Take(count).Load();
            return _TEntity.Local;
        }

        public ObservableCollection<TEntity> GetSyncedList(Func<TEntity, bool> expression, int count = 1000)
        {
            // For Databinding with WPF.
            // Before calling this method you need to fill the context by using `Load()` method.
            _TEntity.Where(expression).Take(count);
            _TEntity.Load();
            return _TEntity.Local;
        }

        public ObservableCollection<TEntity> GetSyncedList(IQueryable<TEntity> expression, int count = 1000)
        {
            expression.Load();
            return _TEntity.Local;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _UOW.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}