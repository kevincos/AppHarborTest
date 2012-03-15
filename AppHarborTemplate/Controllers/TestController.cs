using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppHarborTemplate.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View("_Debug");
        }

        public ActionResult Exception()
        {
            throw new ApplicationException("test");
        }
    }
}
