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
            //年月でDBrecord抽出
            var query = from p in db.Mains
                        where p.Date.Year == Year & p.Date.Month == Month
                        select p;

            //Aについてジャンル別に合計金額を抽出
            Decimal? Shokuhi_A = query.Where(p => p.Genre == "食費")
                                .Where(p => p.Person == "A")
                                .Select(p => p.Price).Sum();

            Decimal? Konetsuhi_A = query.Where(p => p.Genre == "光熱費")
                                   .Where(p => p.Person == "A")
                                   .Select(p => p.Price).Sum();

            Decimal? Nitiyohin_A = query.Where(p => p.Genre == "日用品")
                                .Where(p => p.Person == "A")
                                .Select(p => p.Price).Sum();

            Decimal? Extra_A = query.Where(p => p.Genre == "その他")
                            .Where(p => p.Person == "A")
                            .Select(p => p.Price).Sum();

            //Bについてジャンル別に合計金額を抽出
            Decimal? Shokuhi_B = query.Where(p => p.Genre == "食費")
                    .Where(p => p.Person == "B")
                    .Select(p => p.Price).Sum();

            Decimal? Konetsuhi_B = query.Where(p => p.Genre == "光熱費")
                                   .Where(p => p.Person == "B")
                                   .Select(p => p.Price).Sum();

            Decimal? Nitiyohin_B = query.Where(p => p.Genre == "日用品")
                                .Where(p => p.Person == "B")
                                .Select(p => p.Price).Sum();

            Decimal? Extra_B = query.Where(p => p.Genre == "その他")
                            .Where(p => p.Person == "B")
                            .Select(p => p.Price).Sum();

            // AについてChart用のリスト作成
            List<Decimal> ChartData_A = new List<Decimal>() { Shokuhi_A == null ? 0 : (Decimal)Shokuhi_A, Konetsuhi_A == null ? 0 : (Decimal)Konetsuhi_A,
                                                         Nitiyohin_A == null ? 0 : (Decimal)Nitiyohin_A, Extra_A == null ? 0 : (Decimal)Extra_A };


            // BについてChart用のリスト作成
            List<Decimal> ChartData_B = new List<Decimal>() { Shokuhi_B == null ? 0 : (Decimal)Shokuhi_B, Konetsuhi_B == null ? 0 : (Decimal)Konetsuhi_B,
                                                         Nitiyohin_B == null ? 0 : (Decimal)Nitiyohin_B, Extra_B == null ? 0 : (Decimal)Extra_B };

            // Jsonデータ作成
            var js = new System.Web.Script.Serialization.JavaScriptSerializer();
            
            string JsonString_A = js.Serialize(ChartData_A);
            ViewBag.JsonString_A = JsonString_A;

            string JsonString_B = js.Serialize(ChartData_B);
            ViewBag.JsonString_B = JsonString_B;

            return View();

        }
    }
}