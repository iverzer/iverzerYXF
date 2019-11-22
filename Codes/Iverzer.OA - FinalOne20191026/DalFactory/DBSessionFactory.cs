using Iverzer.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DalFactory
{
    public class DBSessionFactory
    {
        private DBSessionFactory()
        {

        }
        public static IDBSession CurrentDBSession
        {
            get { return GetCurrentDBSession(); }
        }
        private static IDBSession GetCurrentDBSession()
        {
            DBSession db = CallContext.GetData("CurrentDBSession") as DBSession;
            if (db == null)
            {
                db = new DBSession();
                CallContext.SetData("CurrentDBSession", db);
            }
            return db;
         }
    }
}
