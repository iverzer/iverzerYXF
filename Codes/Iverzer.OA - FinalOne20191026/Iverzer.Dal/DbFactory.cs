using Iverzer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Iverzer.Dal
{
    public class DbFactory
    {
        private DbFactory()
        {

        }

        public static DbContext CurrentDB
        {
            
            get
            {
                return GetCurrentDB();
            }
        }
        private static DbContext GetCurrentDB()
        {
            IverzerOA db = CallContext.GetData("GetCurrentDB") as IverzerOA;
            if (db == null)
            {
                db = new IverzerOA();
                CallContext.SetData("GetCurrentDB",db);
            }
            return db;
        }
    }
}
