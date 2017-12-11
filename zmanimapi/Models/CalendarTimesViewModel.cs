using System;
using Zmanim.JewishCalendar;
namespace zmanimapi.Models
{
    public class CalendarTimesViewModel
    {
        public CalendarTimesViewModel()
        {
        }
        public Daf DafYomiBavli { get; set; }
        public int DayOfOmer { get; set; }
        public int DayOfChanukah { get; set; }
        public bool isYomTov { get; set; }
        public bool isYomTovIssurMelacha { get; set; }
        public JewishCalendar.JewishHoliday JewishHoliday { get; set; }
        public JewishCalendar.JewishMonth JewishMonth { get; set; }
        public JewishCalendar.JewishYearType JewishYearType { get; set; }
        public bool isChanukah { get; set; }
        public bool isCholHamoed { get; set; }
        public bool isErevRoshChodesh { get; set; }
        public bool isRoshChodesh { get; set; }
        public bool isErevYomTov { get; set; }
        public bool isTaanis { get; set; }
    }
}
