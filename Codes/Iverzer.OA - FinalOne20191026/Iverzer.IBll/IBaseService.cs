using Iverzer.IDal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iverzer.IBll
{
    public interface IBaseService<T>
        where T:class,new()
    {
        IDBSession DBSession { get; }
        T Add(T t);
        bool Delete(int id);
        bool Delete(T t);
        bool Delete(int[] ids);

        bool Edit(T t);

        

        IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetPageList<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderByLambda, int pageIndex, int pageSize, out int total, bool isAscOrderBy);
    }
}
