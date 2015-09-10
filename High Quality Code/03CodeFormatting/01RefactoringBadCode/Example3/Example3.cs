namespace _03Example3
{
    using System;
    using System.Collections.Generic;

    public class Example3
    {
        public static void Main(string[] args)
        {
        }

        private MonthCalendarModel GetMonthCalendar(int year, int month, string roleId, string doctorId)
        {
            var days = new List<DayCalendarModel>();
            var today = DateTime.Today;
            var firstDay = new DateTime(year, month, 1);
            int firstDayOfWeek = 0;
            if (firstDay.DayOfWeek == DayOfWeek.Monday)
            {
                firstDayOfWeek = 1;
            }

            if (firstDay.DayOfWeek == DayOfWeek.Tuesday)
            {
                firstDayOfWeek = 2;
            }

            if (firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                firstDayOfWeek = 3;
            }

            if (firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                firstDayOfWeek = 4;
            }

            if (firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                firstDayOfWeek = 5;
            }

            if (firstDay.DayOfWeek == DayOfWeek.Saturday)
            {
                firstDayOfWeek = 6;
            }

            if (firstDay.DayOfWeek == DayOfWeek.Sunday)
            {
                firstDayOfWeek = 7;
            }

            for (int i = firstDayOfWeek - 1; i > 0; i--)
            {
                DateTime day = firstDay.AddDays(-i);
                days.Add(new DayCalendarModel { Available = -1, Day = day.Day, Enabled = false, CssClass = string.Empty });
            }

            DateScheduler dateScheduler = this.GetDateScheduler(roleId, doctorId);
            DateTime date;
            for (date = firstDay; date.Month == month; date = date.AddDays(1))
            {
                string cssClass = dateScheduler.CheckDate(date, true) ? "free" : "disbl";
                bool enabled = date >= today;
                cssClass = enabled ? cssClass : string.Empty;
                days.Add(new DayCalendarModel() { Available = 3, Day = date.Day, Enabled = enabled, CssClass = cssClass, Date = date.ToString(FormatHelper.DateOnlySerializationFormat) });
            }
            if (date.DayOfWeek != DayOfWeek.Monday)
            {
                for (; this.GetDayOfWeek(date.DayOfWeek) <= 7; date = date.AddDays(1))
                {
                    days.Add(new DayCalendarModel() { Available = -1, Day = date.Day, Enabled = false, CssClass = string.Empty });
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        break;
                    }
                }
            }

            // пропущено ...
        }

        private DateScheduler GetDateScheduler(string roleId, string doctorId)
        {
            throw new NotImplementedException();
        }

        private int GetDayOfWeek(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == System.DayOfWeek.Sunday)
            {
                return 7;
            }
            return (int)dayOfWeek;
        }
    }

    internal class FormatHelper
    {
        public static IFormatProvider DateOnlySerializationFormat { get; set; }
    }
}
