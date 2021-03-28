using MvcMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebDesign.ViewModels;
using System.Data.Objects.SqlClient;

namespace WebDesign.Controllers
{
    [RoutePrefix("API/Main")]
    public class MainAPIController : ApiController
    {
        private MainDBContext db = new MainDBContext();
        [HttpGet]
        [Route("GetCalendarEvents")]
        public IEnumerable<CalenderEvent> GetCalenderMonth(int Year, int Month)
        {

            var result = from p in db.Mains
                         where p.Date.Year == Year & p.Date.Month == Month
                         orderby p.ID
                         select new CalenderEvent() { id = SqlFunctions.StringConvert((double)p.ID), title = p.Genre + p.Price.ToString("C"), start = p.Date.ToString("yyyy-MM-dd") + "T00:00:00", end = p.Date.ToString("yyyy-MM-dd") + "T00:00:00" };
            return result.ToList();
        }
    }
}
