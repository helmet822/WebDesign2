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
        public ActionResult Index(int Year, int Month)
        {
            //月のドロップダウンリスト用
            var MonthLst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            ViewBag.Month = new SelectList(MonthLst, DateTime.Today.Month);

            //年のドロップダウンリスト用
            var YearLst = new List<int>() { 2021,2022,2023,2024,2025,2026,2027,2028,2029,2030,
                                             2031,2032,2033,2034,2035,2036,2037,2038,2039,2040,
                                             2041,2042,2043,2044,2045,2046,2047,2048,2049,2050};

            ViewBag.Year = new SelectList(YearLst, DateTime.Today.Year);
            


            //年月でDBrecord抽出
            var query = from p in db.Mains
                        where p.Date.Year == Year & p.Date.Month == Month
                        select p;

            //Aについてジャンル別に合計金額を抽出
            Decimal? Konetsuhi_A = query.Where(p => p.Genre == "光熱費")
                                   .Where(p => p.Person == "A")
                                   .Select(p => p.Price).Sum(p => (Decimal?)p);

            Decimal? Shokuhi_A = query.Where(p => p.Genre == "食費")
                                .Where(p => p.Person == "A")
                                .Select(p => p.Price).Sum(p => (Decimal?)p);


            Decimal? Nitiyohin_A = query.Where(p => p.Genre == "日用品")
                                .Where(p => p.Person == "A")
                                .Select(p => p.Price).Sum(p => (Decimal?)p);

            Decimal? Extra_A = query.Where(p => p.Genre == "その他")
                            .Where(p => p.Person == "A")
                            .Select(p => p.Price).Sum(p => (Decimal?)p);

            //Bについてジャンル別に合計金額を抽出
            Decimal? Konetsuhi_B = query.Where(p => p.Genre == "光熱費")
                                   .Where(p => p.Person == "B")
                                   .Select(p => p.Price).Sum(p => (Decimal?)p);

            Decimal? Shokuhi_B = query.Where(p => p.Genre == "食費")
                    .Where(p => p.Person == "B")
                    .Select(p => p.Price).Sum(p => (Decimal?)p);


            Decimal? Nitiyohin_B = query.Where(p => p.Genre == "日用品")
                                .Where(p => p.Person == "B")
                                .Select(p => p.Price).Sum(p => (Decimal?)p);

            Decimal? Extra_B = query.Where(p => p.Genre == "その他")
                            .Where(p => p.Person == "B")
                            .Select(p => p.Price).Sum(p => (Decimal?)p);

            // AについてChart用のリスト作成
            List<Decimal> ChartData_A = new List<Decimal>() { Konetsuhi_A == null ? 0 : (Decimal)Konetsuhi_A,Shokuhi_A == null ? 0 : (Decimal)Shokuhi_A, 
                                                         Nitiyohin_A == null ? 0 : (Decimal)Nitiyohin_A, Extra_A == null ? 0 : (Decimal)Extra_A };


            // BについてChart用のリスト作成
            List<Decimal> ChartData_B = new List<Decimal>() { Konetsuhi_B == null ? 0 : (Decimal)Konetsuhi_B,Shokuhi_B == null ? 0 : (Decimal)Shokuhi_B, 
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