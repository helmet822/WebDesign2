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

            var Aquery = from p in db.Mains
                         where p.Date.Year == Year & p.Date.Month == Month & p.Person == "A"
                         orderby p.ID
                         select p;

            var Bquery = from p in db.Mains
                         where p.Date.Year == Year & p.Date.Month == Month & p.Person == "B"
                         orderby p.ID
                         select p;

            List<CalenderEvent> result = new List<CalenderEvent>();
            foreach (var data in Aquery) {
                result.Add(new CalenderEvent() { id = data.ID.ToString(), title = data.Genre + data.Price.ToString("C"), start = data.Date.ToString("yyyy-MM-dd") + "T00:00:00", end = data.Date.ToString("yyyy-MM-dd") + "T00:00:00", color ="#0000cd" }); 

            }

            foreach (var data in Bquery)
            {
                result.Add(new CalenderEvent() { id = data.ID.ToString(), title = data.Genre + data.Price.ToString("C"), start = data.Date.ToString("yyyy-MM-dd") + "T00:00:00", end = data.Date.ToString("yyyy-MM-dd") + "T00:00:00", color = "#ff4500" });

            }

            return result;

        }
    }
}
