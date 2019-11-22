using DalFactory;

using Iverzer.IDal;
using Iverzer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iverzer.Bll
{
    public abstract class BaseService<T>
        where T:class,new()
    {
       
        public IDBSession DBSession
        {
            get { return DBSessionFactory.CurrentDBSession; }
        }
        public IBaseDal<T> CurrentDal { set; get; }
        public abstract void GetCurrentDal();
        public BaseService()
        {
            GetCurrentDal();
        }
        public T Add(T t)
        {
            CurrentDal.Add(t);
            DBSession.SaveChanges();
            return t;
        }
        public bool Delete(int id)
        {
            CurrentDal.Delete(id);
            return DBSession.SaveChanges() > 0;
        }
        public bool Delete(T t)
        {
            CurrentDal.Delete(t);
            return DBSession.SaveChanges() > 0;
        }
        public bool Delete(int[] ids)
        {
            CurrentDal.Delete(ids);
            return DBSession.SaveChanges() > 0;
        }

        public bool Edit(T t)
        {
            CurrentDal.Edit(t);
            return DBSession.SaveChanges() > 0;
        }

        

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetList(whereLambda);
        }

        public IQueryable<T> GetPageList<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderByLambda, int pageIndex, int pageSize, out int total, bool isAscOrderBy)
        {
            
            total = 0;
            return CurrentDal.GetPageList<Tkey>(whereLambda, orderByLambda, pageIndex, pageSize, out total, isAscOrderBy);
        }

       
    }
}
