using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace WebDesign.Controllers
{
    [RoutePrefix("API/Chart")]
    public class ChartAPIController : ApiController
    {
        // GET: ChartAPI
        [Route("GetSummaryTable")]
        public string GetSummaryTable()
        {
            return @"{""type"": ""pie"",""data"":{""datasets"":[{""data"":[2.0,1.0,3.0,4.0,5.0],""backgroundColor"":[""rgb(255, 99, 132)"", ""rgb(255, 99, 132)"",                        ""rgb(255, 99, 132)"",                        ""rgb(255, 99, 132)"",                        ""rgb(255, 99, 132)"",                   ],                    ""label"": ""Dataset 1""                }],                ""labels"":[                    ""Red"",                    ""Orange"",                    ""Yellow"",                    ""Green"",                    ""Blue""                ]            },            ""options"":                {                ""responsive"": true            }            };";
        }
    }
}