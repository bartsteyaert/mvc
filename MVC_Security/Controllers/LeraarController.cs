using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Security.Controllers
{
    [Authorize(Users = "Leraar1@mvc.net,Leraar2@mvc.net,Leraar3@mvc.net")]
    public class LeraarController : Controller
    {
        // GET: Leraar
        public ActionResult Index()
        {
            return View();
        }
    }
}