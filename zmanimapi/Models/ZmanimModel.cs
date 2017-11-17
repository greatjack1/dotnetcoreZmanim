using System;
using System.Collections.Generic;
namespace zmanimapi.Models
{
    public class ZmanimModel
    {
        public ZmanimModel()
        {
            
        }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int timeformat { get; set; }
        public String timezone { get; set; }
        public double elevation { get; set; }
        public DateTime? date { get; set; }
        //this zmanim list is the model which the views use to generate the views
        public Dictionary<String, DateTime?> zmanimList = new Dictionary<string, DateTime?>();
    }
}
