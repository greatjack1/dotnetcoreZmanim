using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using zmanimapi.Models;

namespace zmanimapi.Views
{
    public class JsonView :IViewable
    {
        private String _Json ="";
        public JsonView(ZmanimModel model)
        {
            //create the formatter for the date based on the timeformat in the model
            String formatter;
            if(model.timeformat==24){
                formatter = "{0:H:mm:ss:tt}";
            } else {
                formatter = "{0:h:mm:ss:tt}"; 
            }
            Dictionary<String,DateTime?> zmanim = model.zmanimList;
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartObject();
                //write the date of the zmanim as a property in the json
                writer.WritePropertyName("Date");
                writer.WriteValue(String.Format("{0:MM/dd/yyyy}", zmanim["Alos16point1Degrees"].GetValueOrDefault()));
                foreach (KeyValuePair<string, DateTime?> entry in zmanim)
                {
                    writer.WritePropertyName(entry.Key);
                    writer.WriteValue(String.Format(formatter, entry.Value));
                  }
                writer.WriteEndObject();
            }
            //store the json that was created in the string builder into the _Json string
            _Json = sb.ToString();
        }
        public string getView(){
            return _Json;
        }
    }
}
