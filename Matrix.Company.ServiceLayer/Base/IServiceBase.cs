using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Matrix.Company.ServiceLayer.Base
{
    public interface IServiceBase<TEntity> : IDisposable
    {
        /// <summary>
        /// یک کاربر را بر اساس اطلاعات لاگین او پیدا می‌کند
        /// </summary>
        /// <param name="username">نام کاربری</param>
        /// <param name="password">کلمه عبور</param>
        /// <returns>کاربر احتمالی یافت شده</returns>
        //TEntity Find(string username, string password);

        /// <summary>
        /// یافتن یک کاربر بر اساس کلید اصلی او
        /// </summary>
        /// <param name="userId">شماره کاربر</param>
        /// <returns>کاربر احتمالی یافت شده</returns>
        //TEntity Find(int Id);

        /// <summary>
        /// یک شیء کاربر را به زمینه ایی اف اضافه می‌کند
        /// </summary>
        /// <param name="data">وهله‌ای شیء کاربر</param>
        /// <returns>کاربر اضافه شده به زمینه</returns>
        TEntity Add(TEntity data);

        void Add(IList<TEntity> data);

        void Add(ICollection<TEntity> data);

        void Delete(TEntity TEntity);

        void Delete(object key);

        void Delete(Func<TEntity, bool> expression);

        void Edit(int id, TEntity TEntity);

        void Edit(string id, TEntity TEntity);

        void Edit(TEntity TEntity);

        TEntity Find(object key);

        TEntity Find(Func<TEntity, bool> expression);

        TEntity Find(TEntity data);

        IList<TEntity> All();

        IList<TEntity> All(Func<TEntity, bool> expression, bool list = true);

        IList<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// جهت مقاصد انقیاد داده‌ها در دبلیو پی اف طراحی شده است
        /// لیستی از کاربران سیستم را باز می‌گرداند
        /// </summary>
        /// <param name="count">تعداد کاربر مد نظر</param>
        /// <returns>لیستی از کاربران</returns>
        ObservableCollection<TEntity> GetSyncedListInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        ObservableCollection<TEntity> GetSyncedList(int count = 1000);

        ObservableCollection<TEntity> GetSyncedList(Func<TEntity, bool> expression, int count = 1000);

        ObservableCollection<TEntity> GetSyncedList(IQueryable<TEntity> expression, int count = 1000);
    }
}