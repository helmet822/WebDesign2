using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDesign.ViewModels;
using System.Data.Objects.SqlClient;
using MvcMain.Models;


namespace WebDesign.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        //public ActionResult Index(){
        // return View();



        private MainDBContext db = new MainDBContext();
        [HttpGet]
        public ActionResult GetChartData(int Year, int Month)
        {

            var query = from p in db.Mains
                        where p.Date.Year == Year & p.Date.Month == Month
                        select p;

            Decimal? Shokuhi = query.Where(p => p.Genre == "食費")
                          　　.Select(p => p.Price).Sum();

            Decimal? Konetsuhi = query.Where(p => p.Genre == "光熱費")
                               .Select(p => p.Price).Sum();

            Decimal? Nitiyohin = query.Where(p => p.Genre == "日用品")
                                .Select(p => p.Price).Sum();

            Decimal? Extra = query.Where(p => p.Genre == "その他")
                            .Select(p => p.Price).Sum();

            List<Decimal> ChartData = new List<Decimal>() { Shokuhi == null ? 0 : (Decimal)Shokuhi, Konetsuhi == null ? 0 : (Decimal)Konetsuhi,
                                                         Nitiyohin == null ? 0 : (Decimal)Nitiyohin, Extra == null ? 0 : (Decimal)Extra };

            var js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string JsonString = js.Serialize(ChartData);

            ViewBag.JsonString = JsonString;

            return View();

        }
    }
}