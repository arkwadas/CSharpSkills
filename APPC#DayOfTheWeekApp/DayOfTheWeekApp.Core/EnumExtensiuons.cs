using System;
using System.Collections.Generic;
using System.Text;

namespace DayOfTheWeekApp.Core
{
    public static class EnumExtensiuons
    {
        public static string ToPolishString(this DayOfTheWeek dayOfTheWeek)
        {
            switch (dayOfTheWeek)
            {
                case DayOfTheWeek.monday:
                    return "poniedziałek";
                case DayOfTheWeek.Tuesday:
                    return "wtorek";
                case DayOfTheWeek.Wednesday:
                    return "środa";
                case DayOfTheWeek.Thursday:
                    return "czwartek";
                case DayOfTheWeek.Friday:
                    return "piatek";
                case DayOfTheWeek.Saturday:
                    return "sobota";
                case DayOfTheWeek.Sunday:
                    return "niedziela";

                default:
                    return "Poniedziałek";
            }
        }

    }
}
