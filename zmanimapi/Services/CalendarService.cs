using System;
using zmanimapi.Models;
using Zmanim.JewishCalendar;
namespace zmanimapi.Services
{
    public class CalendarService
    {
        private CalendarModel calModel;

        public CalendarService(CalendarModel model)
        {
            calModel = model;
        }
        public CalendarTimesViewModel getViewModel(){
            JewishCalendar cal = new JewishCalendar();
            //create the view model
            CalendarTimesViewModel vm = new CalendarTimesViewModel();
            DateTime date = calModel.date.GetValueOrDefault();
            vm.DafYomiBavli = cal.GetDafYomiBavli(date);
            vm.DayOfChanukah = cal.GetDayOfChanukah(date);
            vm.DayOfOmer = cal.GetDayOfOmer(date);
            vm.isChanukah = cal.IsChanukah(date);
            vm.isCholHamoed = cal.IsCholHamoed(date,calModel.isIsrael);
            vm.isErevRoshChodesh = cal.IsErevRoshChodesh(date);
            vm.isErevYomTov = cal.IsErevYomTov(date,calModel.isIsrael);
            vm.isRoshChodesh = cal.IsRoshChodesh(date);
            vm.isTaanis = cal.IsTaanis(date, calModel.isIsrael);
            vm.isYomTov = cal.IsYomTov(date, calModel.isIsrael);
            vm.isYomTovIssurMelacha = cal.IsYomTovAssurBemelacha(date, calModel.isIsrael);
            vm.JewishHoliday = cal.GetJewishHoliday(date, calModel.isIsrael);
            vm.JewishMonth = cal.GetJewishMonth(date);
            vm.JewishYearType = cal.GetJewishYearType(date);
            return vm;
        }
    }
}
