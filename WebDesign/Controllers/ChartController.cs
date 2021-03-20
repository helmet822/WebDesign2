using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDesign.Controllers
{
    [RoutePrefix("Chart")]
    public class ChartController : Controller{
        // GET: Chart
        [Route("")]
        [Route("Index")]
        public ActionResult Index(){
            return View();
        }
    }
}