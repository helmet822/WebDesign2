using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDesign.ViewModels {
    public class CalenderEvent {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
    }

}