using Iverzer.Dal;
using Iverzer.IDal;
using Iverzer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DalFactory
{
    public class DalFactory
    {
        private DalFactory() { }
        public static IUserInfoDal UserInfoDal
        {
            get { return CreateUserInfoDal(); }
        }
        private static IUserInfoDal CreateUserInfoDal()
        {
            var strs = System.Configuration.ConfigurationManager.AppSettings["UserInfoDal"].Split(',');
            return Assembly.Load(strs[0].ToString()).CreateInstance(strs[1].ToString()) as IUserInfoDal;
            //return new UserInfoDal();
        }
    }
}
