using Iverzer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iverzer.Dal
{
    public class BaseDal<T>
        where T:class,new ()
    {
        public DbContext CurrentDB
        {
            get { return DbFactory.CurrentDB; }
        }
        
        public T Add(T t)
        {
            CurrentDB.Set<T>().Add(t);
            //return dbContext.SaveChanges();
            return t;
        }
        public bool Delete(int id)
        {
            T t = CurrentDB.Set<T>().Find(id);
            CurrentDB.Set<T>().Remove(t);
            //return dbContext.SaveChanges();
            return true;
        }
        public bool Delete(T t)
        {
            CurrentDB.Set<T>().Remove(t);
            //return dbContext.SaveChanges();
            return true;

        }
        public bool Delete(int[] ids)
        {
            var length = ids.Length;
            for (int i = 0; i < length; i++)
            {
                CurrentDB.Set<T>().Remove(CurrentDB.Set<T>().Find(ids[i]));
            }

            //return dbContext.SaveChanges();
            return true;
        }

        public bool Edit(T t)
        {
            CurrentDB.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            //return dbContext.SaveChanges();
            return true;
        }

        public T GetById(int id)
        {
            return CurrentDB.Set<T>().Find(id);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDB.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> GetPageList<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderByLambda, int pageIndex, int pageSize, out int total, bool isAscOrderBy)
        {
            total = CurrentDB.Set<T>().Where(whereLambda).Count();
            if (isAscOrderBy)
            {
                return CurrentDB.Set<T>().Where(whereLambda)
                        .OrderBy(orderByLambda)
                        .Skip((pageIndex < 0 ? 1 : pageSize < 0 ? 1 : pageSize - 1) * pageSize < 0 ? 1 : pageSize)
                        .Take(pageSize <= 0 ? 0 : pageSize);
            }
            return CurrentDB.Set<T>().Where(whereLambda)
                .OrderByDescending(orderByLambda)
                .Skip((pageIndex < 0 ? 1 : pageSize - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
