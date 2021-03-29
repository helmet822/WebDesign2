using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMain.Models;
using System.Diagnostics;
using System.Globalization;

namespace WebDesign.Controllers
{
    //[RoutePrefix("Main")]
    public class MainController : Controller
    {
        private MainDBContext db = new MainDBContext();

        //[Route("")]
        //[Route("Index")]
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        // GET: Main/Details/5
        //[Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        //// GET: Main/Create
        //[Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        //[Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Price,Genre,Person,Memo")] Main main)
        {
            if (ModelState.IsValid)
            {
                db.Mains.Add(main);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(main);
        }

        // GET: Main/Edit/5
        //[Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        // POST: Main/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        //[Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Price,Genre,Person,Memo")] Main main)
        {
            if (ModelState.IsValid)
            {
                db.Entry(main).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(main);
        }

        // GET: Main/Delete/5
        //[Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        // POST: Main/Delete/5
        //[Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Main main = db.Mains.Find(id);
            db.Mains.Remove(main);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Main/Seisan
        public ActionResult Seisan(int Year, int Month)
        {

            //指定した月のDBレコード
            var YearMonth = db.Mains
                .Where(y => y.Date.Year == Year)
                .Where(m => m.Date.Month == Month);

            Decimal SumPrice = 0;

            if (YearMonth.Count() > 0)
            {
                //指定した月の合計
                SumPrice = YearMonth
                .Select(p => p.Price).Sum();
            }

            //Aの月合計
            Decimal? APrice = YearMonth
            .Where(ap => ap.Person.Equals("A"))
            .Select(p => p.Price).Sum(p => (Decimal?)p);

            //Bの月合計
            Decimal? BPrice = YearMonth
            .Where(ap => ap.Person.Equals("B"))
            .Select(p => p.Price).Sum(p => (Decimal?)p);

            //支払者
            String Payer;
            //支払額
            Decimal Pay = 0;
            if (APrice == null)
            {
                APrice = 0;
            }

            if (BPrice == null)
            {
                BPrice = 0;
            }

            if (APrice > BPrice)
            {
                Payer = "B";
                Pay = SumPrice / 2 - (Decimal)BPrice;
;
            }
            else if (APrice == BPrice)
            { Payer = "A";
                Pay = 0;
            }
            else
            {
                Payer = "A";
                Pay = SumPrice / 2 - (Decimal)APrice;
            }

            ViewBag.Year = Year.ToString() + "年";
            ViewBag.Month = Month.ToString() + "月";

            CultureInfo cultureJP = CultureInfo.CreateSpecificCulture("ja-JP");
            ViewBag.APrice = APrice == null ? "" : ((Decimal)APrice).ToString("C", cultureJP);
            ViewBag.BPrice = BPrice == null ? "" : ((Decimal)BPrice).ToString("C", cultureJP);

            ViewBag.Pay = Pay.ToString("C", cultureJP);
            ViewBag.Payer = Payer;

            return View();
            //return View(YearMonth);

        }

    }
}
