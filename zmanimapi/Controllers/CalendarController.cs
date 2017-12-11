using System;
using Microsoft.AspNetCore.Mvc;
using zmanimapi.Models;
using zmanimapi.Services;

namespace zmanimapi.Controllers
{
    public class CalendarController : Controller
    {
        public JsonResult Index(String date, bool? isIsrael = null){
            //verify that we received all of the parameters
            DateTime validDate;
            //if the date string cant be parsed then return that a valid date must be provided
            if(!DateTime.TryParse(date,out validDate)){
                return Json("date is a required parameter, an example of a date is 2/2/14");
            }
            //if is israel is null then return a message that its missing
            if(isIsrael is null){
                return Json("isIsrael is a required parameter, please specify true or false");
            }
            //put the values in the model
            CalendarModel model = new CalendarModel();
            model.date = validDate;
            model.isIsrael = isIsrael.GetValueOrDefault();
            //pass the model to the service to generate the calendar times
            CalendarService service = new CalendarService(model);

            //return the Calendar View model object
            return Json(service.getViewModel());
        }
    
    }
}
