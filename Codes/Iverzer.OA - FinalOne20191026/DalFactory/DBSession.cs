using Iverzer.IDal;
using Iverzer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalFactory
{
    public class DBSession:IDBSession
    {
        public IUserInfoDal UserInfoDal
        {
            get { return DalFactory.UserInfoDal; }
        }
        
        public int SaveChanges()
        {
            return UserInfoDal.CurrentDB.SaveChanges();
        }
    }
}
