using DalFactory;
using Iverzer.Dal;
using Iverzer.IDal;
using Iverzer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Iverzer.IBll;
using System.Data.Entity;

namespace Iverzer.Bll
{
    public class UserInfoService :BaseService<UserInfo>, IUserInfoService
    {
       

        public override void GetCurrentDal()
        {
            CurrentDal = DBSession.UserInfoDal;
        }
    }
}
