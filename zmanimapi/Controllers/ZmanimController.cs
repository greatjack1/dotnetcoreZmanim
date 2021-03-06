﻿using System;
using Microsoft.AspNetCore.Mvc;
using Zmanim.TimeZone;
using zmanimapi.Models;
using zmanimapi.Services;
using zmanimapi.Views;

namespace zmanimapi.Controllers
{
  //  [Route("[controller]")]
    public class ZmanimController : Controller
    {

        public String Index(String date, String timezone, double latitude, double longitude, double elevation, String timeformat, String format,String mode)
        {
            //if any of the parameters are empty then return a error saying parameters are missing
            if (date == "")
            {
                Console.WriteLine("date is missing, using todays date");
            }
            if (latitude == 0.0)
            {
                return "Error: latitude is a required parameter";
            }
            if (longitude == 0.0)
            {
                return "Error: longitude is a required parameter";
            }
            //check if the timezone is valid
            try
            {
                ITimeZone timeZone = new WindowsTimeZone(timezone);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Time zone is invalid returning error " + ex.Message);
                return "The time zone you have submitted is not valid. Time zones should be formatted like America/New_York";
            }

            //create a general try catch to prevent major errors
           try
          {

                //create a model to pass to the zmanimService
                ZmanimModel model = new ZmanimModel();
                //store the controller params in the model
                model.latitude = latitude;
                model.longitude = longitude;
                model.elevation = elevation;
                model.mode = mode;
                model.timeformat = timeformat;
                model.timezone = timezone;
                //check if the date is parsable, if its not then set the model date to null
                DateTime theDate;
                if (DateTime.TryParse(date, out theDate))
                {
                    model.date = theDate;
                }
                else
                {
                    model.date = null;
                }
                //now pass the model to the zmanim service
                ZmanimService service = new ZmanimService(model);
                //make sure format is instantiated, if its not then instantiate it
                if (format == null)
                {
                    format = "json";
                }
                //pass the model to the view and return the view
                //choose the view based on the format parameter
                if (format.ToLower() == "xml")
                {
                    XmlView view = new XmlView(model);
                    return view.getView();
                }
                else
                { //use json as the default format
                    JsonView view = new JsonView(model);
                    return view.getView();
                }
            }
            catch (Exception ex)
          {
                  Console.WriteLine("Error:" + ex.Message);
                     //return a error message
               return "There was a error generating the zmanim, please ensure all of your input parameters are correct and try again later";
          }


        }

    }

}