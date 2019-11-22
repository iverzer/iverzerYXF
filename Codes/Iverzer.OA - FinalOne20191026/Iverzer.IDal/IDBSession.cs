using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iverzer.IDal
{
    public interface IDBSession
    {
        IUserInfoDal UserInfoDal { get; }
        int SaveChanges();
    }
}
