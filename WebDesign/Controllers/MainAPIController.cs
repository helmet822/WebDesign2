using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebDesign.ViewModels;

namespace WebDesign.Controllers {
    [RoutePrefix("API/Main")]
    public class MainAPIController : ApiController {
        [HttpGet]
        [Route("GetCalendarEvents")]
        public IEnumerable<CalenderEvent> GetCalenderMonth() {
            var dummyData = new CalenderEvent[] {
                new CalenderEvent() { id = "262399c4-3d9c-4d4f-b090-c8d8e8b50358", title = "ガス代", description="3,750円", start = "2021-03-10T13:00:00", end = "2021-03-10T13:00:00"},
                new CalenderEvent() { id = "3a05c506-3e5a-4e33-bd9e-e2a92ae37e27", title = "食費", description="12,870円", start = "2021-03-13T11:30:00", end = "2021-03-13T11:30:00", color = "#257e4a"},
            };
            var result = from d in dummyData
                         select d;
            return result;
        }
    }
}
