using System;
using System.Collections.Generic;
namespace zmanimapi.Models
{
    public class ZmanimModel
    {
        public ZmanimModel()
        {
            
        }
        //this zmanim list is the model which the views use to generate the views
        public Dictionary<String, DateTime?> zmanimList = new Dictionary<string, DateTime?>();
    }
}
