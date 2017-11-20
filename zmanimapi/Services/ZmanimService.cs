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
        public ZmanimService(ZmanimModel model)
        {
            String locationName = "Random";
            double latitude = model.latitude;
            double longitude = model.longitude;
            double elevation = model.elevation;
            ITimeZone timeZone = new WindowsTimeZone(model.timezone);
            GeoLocation location = new GeoLocation(locationName, latitude, longitude,
            elevation, timeZone);
            ComplexZmanimCalendar czc;
            //if Datetime is null so then instantiate the zmanim with todays date
            if (!model.date.HasValue)
            {
                Console.WriteLine("Date was not submitted so using todays date");
                czc = new ComplexZmanimCalendar(DateTime.Now, location);
            }
            else
            {
                Console.WriteLine("Date was submitted so using the date of" + model.date.ToString());
                czc = new ComplexZmanimCalendar(model.date.GetValueOrDefault(), location);
            }
            //If the request wanted basic mode then use basic zmanim, else print everything
            if (model.mode == "basic") { 
                //insert the zmanim into the model so the controller can create a view from it
                model.zmanimList.Add("Alos16point1Degrees", czc.GetAlos16Point1Degrees());
                model.zmanimList.Add("Sunrise", czc.GetSunrise());
                model.zmanimList.Add("SofZmanShemaMGA", czc.GetSofZmanShmaMGA());
                model.zmanimList.Add("SofZmanShmaGra", czc.GetSofZmanShmaGRA());
                model.zmanimList.Add("SofZmanTefilahGra", czc.GetSofZmanTfilaGRA());
                model.zmanimList.Add("Chatzos", czc.GetChatzos());
                model.zmanimList.Add("MinchaGedolah", czc.GetMinchaGedola());
                model.zmanimList.Add("PlagHamincha", czc.GetPlagHamincha());
                model.zmanimList.Add("Shkia", czc.GetSunset());
                model.zmanimList.Add("Tzais", czc.GetTzais());
                model.zmanimList.Add("CandleLighting", czc.GetCandleLighting());
            }
            else
            {
                //insert the zmanim into the model so the controller can create a view from it
                model.zmanimList.Add("Alos", czc.GetAlos16Point1Degrees());
                model.zmanimList.Add("Alos16point1Degrees", czc.GetAlos16Point1Degrees());
                model.zmanimList.Add("Alos18Degrees", czc.GetAlos18Degrees());
                model.zmanimList.Add("Alos19Point8Degrees", czc.GetAlos19Point8Degrees());
                model.zmanimList.Add("Alos26Degrees", czc.GetAlos26Degrees());
                model.zmanimList.Add("Alos60", czc.GetAlos60());
                model.zmanimList.Add("Alos72", czc.GetAlos72Zmanis());
                model.zmanimList.Add("Alos90", czc.GetAlos90());
                model.zmanimList.Add("Alos90Zmanim", czc.GetAlos90Zmanis());
                model.zmanimList.Add("Alos96", czc.GetAlos96());
                model.zmanimList.Add("Alos96Zmanim", czc.GetAlos96Zmanis());
                model.zmanimList.Add("Alos120", czc.GetAlos120());
                model.zmanimList.Add("Alos120Zmanim", czc.GetAlos120Zmanis());
                model.zmanimList.Add("Misheyakir10.2Degrees", czc.GetMisheyakir10Point2Degrees());
                model.zmanimList.Add("Misheyakir11Degrees", czc.GetMisheyakir11Degrees());
                model.zmanimList.Add("Misheyakir11.5Degrees", czc.GetMisheyakir11Point5Degrees());
                model.zmanimList.Add("Sunrise", czc.GetSunrise());
                model.zmanimList.Add("SofZmanShemaMGA", czc.GetSofZmanShmaMGA());
                model.zmanimList.Add("SofZmanShmaGra", czc.GetSofZmanShmaGRA());
                model.zmanimList.Add("SofZmanShema3HoursBeforeChatzos", czc.GetSofZmanShma3HoursBeforeChatzos());
                model.zmanimList.Add("SofZmanShemaAlos16Point1ToSunset", czc.GetSofZmanShmaAlos16Point1ToSunset());
                model.zmanimList.Add("SofZmanShemaAlos16Point1ToTzaisGeonim7Point083Degrees", czc.GetSofZmanShmaAlos16Point1ToTzaisGeonim7Point083Degrees());
                model.zmanimList.Add("SofZmanShemaAteretTorah", czc.GetSofZmanShmaAteretTorah());
                model.zmanimList.Add("SofZmanShemaMGA18Degrees", czc.GetSofZmanShmaMGA18Degrees());
                model.zmanimList.Add("SofZmanShemaMGA16Point1Degrees", czc.GetSofZmanShmaMGA16Point1Degrees());
                model.zmanimList.Add("SofZmanShemaMGA19point8Degrees", czc.GetSofZmanShmaMGA19Point8Degrees());
                model.zmanimList.Add("SofZmanShemaMGA72", czc.GetSofZmanShmaMGA72Minutes());
                model.zmanimList.Add("SofZmanShemaMGA72Zmanis", czc.GetSofZmanShmaMGA72MinutesZmanis());
                model.zmanimList.Add("SofZmanShemaMGA90", czc.GetSofZmanShmaMGA90Minutes());
                model.zmanimList.Add("SofZmanShemaMGA90Zmanis", czc.GetSofZmanShmaMGA90MinutesZmanis());
                model.zmanimList.Add("SofZmanShemaMGA96", czc.GetSofZmanShmaMGA96Minutes());
                model.zmanimList.Add("SofZmanShemaMGA96Zmanis", czc.GetSofZmanShmaMGA96MinutesZmanis());
                model.zmanimList.Add("SofZmanShemaMGA120", czc.GetSofZmanShmaMGA120Minutes());
                model.zmanimList.Add("SofZmanTefilahGra", czc.GetSofZmanTfilaGRA());
                model.zmanimList.Add("SofZmanTefilahGra2HoursBeforeChatzos", czc.GetSofZmanTfila2HoursBeforeChatzos());
                model.zmanimList.Add("SofZmanTefilahAteretTorah", czc.GetSofZmanTfilahAteretTorah());
                model.zmanimList.Add("SofZmanTefilahMGA72", czc.GetSofZmanTfilaMGA72Minutes());
                model.zmanimList.Add("SofZmanTefilahMGA72Zmanis", czc.GetSofZmanTfilaMGA72MinutesZmanis());
                model.zmanimList.Add("SofZmanTefilahMGA90", czc.GetSofZmanTfilaMGA90Minutes());
                model.zmanimList.Add("SofZmanTefilahMGA90Zmanis", czc.GetSofZmanTfilaMGA90MinutesZmanis());
                model.zmanimList.Add("SofZmanTefilahMGA96", czc.GetSofZmanTfilaMGA96Minutes());
                model.zmanimList.Add("SofZmanTefilahMGA96Zmanis", czc.GetSofZmanTfilaMGA96MinutesZmanis());
                model.zmanimList.Add("SofZmanTefilahMGA120", czc.GetSofZmanTfilaMGA120Minutes());
                model.zmanimList.Add("SolarMidnight", czc.GetSolarMidnight());
                model.zmanimList.Add("Chatzos", czc.GetChatzos());
                model.zmanimList.Add("MinchaGedolah", czc.GetMinchaGedola());
                model.zmanimList.Add("MinchaGedolah16.1Degrees", czc.GetMinchaGedola16Point1Degrees());
                model.zmanimList.Add("MinchaGedolah30MinutesAfterChatzos", czc.GetMinchaGedola30Minutes());
                model.zmanimList.Add("MinchaGedolah72MinutesAfterChatzos", czc.GetMinchaGedola72Minutes());
                model.zmanimList.Add("MinchaGedolahAteretTorah", czc.GetMinchaGedolaAteretTorah());
                model.zmanimList.Add("MinchaKetana", czc.GetMinchaKetana());
                model.zmanimList.Add("MinchaKetanaMGA72Minutes", czc.GetMinchaKetana72Minutes());
                model.zmanimList.Add("MinchaKetanaMGA16.1Degrees", czc.GetMinchaKetana16Point1Degrees());
                model.zmanimList.Add("MinchaKetanaAteretTorah", czc.GetMinchaKetanaAteretTorah());
                model.zmanimList.Add("PlagHamincha", czc.GetPlagHamincha());
                model.zmanimList.Add("PlagHaminchaAteretTorah", czc.GetPlagHaminchaAteretTorah());
                model.zmanimList.Add("PlagHaminchaDayStartAlosEndSunset", czc.GetPlagAlosToSunset());
                model.zmanimList.Add("PlagHaminchaAlos16Point1ToTzaisGeonim7Point083Degrees", czc.GetPlagAlos16Point1ToTzaisGeonim7Point083Degrees());
                model.zmanimList.Add("PlagHamincha18Degrees", czc.GetPlagHamincha18Degrees());
                model.zmanimList.Add("PlagHamincha19.8Degrees", czc.GetPlagHamincha19Point8Degrees());
                model.zmanimList.Add("PlagHamincha26Degrees", czc.GetPlagHamincha26Degrees());
                model.zmanimList.Add("PlagHamincha60", czc.GetPlagHamincha60Minutes());
                model.zmanimList.Add("PlagHamincha72", czc.GetPlagHamincha72Minutes());
                model.zmanimList.Add("PlagHamincha72Zmanis", czc.GetPlagHamincha72MinutesZmanis());
                model.zmanimList.Add("PlagHamincha90", czc.GetPlagHamincha90Minutes());
                model.zmanimList.Add("PlagHamincha90Zmanis", czc.GetPlagHamincha90MinutesZmanis());
                model.zmanimList.Add("PlagHamincha96", czc.GetPlagHamincha96Minutes());
                model.zmanimList.Add("PlagHamincha96Zmanis", czc.GetPlagHamincha96MinutesZmanis());
                model.zmanimList.Add("Shkia", czc.GetSunset());
                model.zmanimList.Add("BainHashmashosRabeinuTam2Stars", czc.GetBainHasmashosRT2Stars());
                model.zmanimList.Add("BainHashmashosRabeinuTam58.5Minutes", czc.GetBainHasmashosRT58Point5Minutes());
                model.zmanimList.Add("BainHashmashosRabeinuTam13.24Degrees", czc.GetBainHasmashosRT13Point24Degrees());
                model.zmanimList.Add("BainHashmashosRabeinuTam13Point5MinutesBefore7Point083Degrees", czc.GetBainHasmashosRT13Point5MinutesBefore7Point083Degrees());
                model.zmanimList.Add("Tzais", czc.GetTzais());
                model.zmanimList.Add("Tzais16.1Degrees", czc.GetTzais16Point1Degrees());
                model.zmanimList.Add("Tzais18Degrees", czc.GetTzais18Degrees());
                model.zmanimList.Add("Tzais26Degrees", czc.GetTzais26Degrees());
                model.zmanimList.Add("Tzais19.8Degrees", czc.GetTzais19Point8Degrees());
                model.zmanimList.Add("Tzais60", czc.GetTzais60());
                model.zmanimList.Add("Tzais90", czc.GetTzais90());
                model.zmanimList.Add("Tzais96", czc.GetTzais96());
                model.zmanimList.Add("Tzais120", czc.GetTzais120());
                model.zmanimList.Add("Tzais72Zmanis", czc.GetTzais72Zmanis());
                model.zmanimList.Add("Tzais90Zmanis", czc.GetTzais90Zmanis());
                model.zmanimList.Add("Tzais96Zmanis", czc.GetTzais96Zmanis());
                model.zmanimList.Add("Tzais120Zmanis", czc.GetTzais120Zmanis());
                model.zmanimList.Add("TzaisAteretTorah", czc.GetTzaisAteretTorah());
                model.zmanimList.Add("CandleLighting", czc.GetCandleLighting());
            }
        }


    }
}
