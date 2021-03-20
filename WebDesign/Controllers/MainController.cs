using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDesign.Controllers
{
    [RoutePrefix("")]
    public class MainController : Controller {
        // GET: Main
        [Route("")]
        [Route("Index")]
        public ActionResult Index() {
            return View();
        }
    }
}