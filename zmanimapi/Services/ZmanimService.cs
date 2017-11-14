using System;
using Zmanim.TimeZone;
using Zmanim.Utilities;
using Zmanim;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using zmanimapi.Models;

namespace zmanimapi.Services
{
    public class ZmanimService
    {
        public ZmanimService(DateTime? Date,String Timezone,double Latitude,double Longitude,int Elevation,ZmanimModel model)
        {
            String locationName = "Random";
            double latitude = Latitude; 
            double longitude = Longitude; 
            double elevation = Elevation;
            ITimeZone timeZone = new WindowsTimeZone(Timezone);
            GeoLocation location = new GeoLocation(locationName, latitude, longitude,
            elevation, timeZone);
            ComplexZmanimCalendar czc;
            //if Datetime is null so then instantiate the zmanim with todays date
            if(!Date.HasValue){
                Console.WriteLine("Date was not submitted so using todays date");
                     czc = new ComplexZmanimCalendar(DateTime.Now, location);
            } else{
                Console.WriteLine("Date was submitted so using the date of" + Date.ToString());
                czc = new ComplexZmanimCalendar(Date.GetValueOrDefault(), location);
            }

            //insert the zmanim into the model so the controller can create a view from it
            model.zmanimList.Add("Alos", czc.GetAlos16Point1Degrees());
            model.zmanimList.Add("Sunrise", czc.GetSunrise());
            model.zmanimList.Add("SofZmanShemaMGA", czc.GetSofZmanShmaMGA());
            model.zmanimList.Add("SofZmanShmaGra", czc.GetSofZmanShmaGRA());
            model.zmanimList.Add("SofZmanTefilahGra", czc.GetSofZmanTfilaGRA());
            model.zmanimList.Add("Chatzos", czc.GetChatzos());
            model.zmanimList.Add("MinchaGedolah", czc.GetMinchaGedola());
            model.zmanimList.Add("PlagHamincha", czc.GetPlagHamincha());
            model.zmanimList.Add("MinchaKetana", czc.GetMinchaKetana());
            model.zmanimList.Add("Shkia", czc.GetSunset());
            model.zmanimList.Add("Tzais", czc.GetTzais());
            model.zmanimList.Add("CandleLighting", czc.GetCandleLighting());
        }
       

    }
}
