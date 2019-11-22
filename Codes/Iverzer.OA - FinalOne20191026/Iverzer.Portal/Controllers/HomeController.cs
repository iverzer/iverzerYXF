using Iverzer.Bll;
using Iverzer.IBll;
using Iverzer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iverzer.Portal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IverzerOA ef = new IverzerOA();
            ef.Database.CreateIfNotExists();
            return View();
        }

        public ActionResult Add()
        {
            IUserInfoService u = new UserInfoService();
            var m= u.GetList(z=>true);
            return Json(m);
        }
    }
}