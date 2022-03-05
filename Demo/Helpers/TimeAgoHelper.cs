using System;

namespace Demo.Helpers
{
    public class TimeAgoHelper
    {
        // return how much time passed since date object
        public static string GetTimeSince(DateTime objDateTime)
        {
            // here we are going to subtract the passed in DateTime from the current time converted to UTC
            TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(objDateTime);
            int intDays = ts.Days;
            int intHours = ts.Hours;
            int intMinutes = ts.Minutes;
            int intSeconds = ts.Seconds;

            if (intDays > 0)
                return string.Format("{0} gün önce", intDays);

            if (intHours > 0)
                return string.Format("{0} saat önce", intHours);

            if (intMinutes > 0)
                return string.Format("{0} dakika önce", intMinutes);

            if (intSeconds > 0)
                return string.Format("{0} saniye önce", intSeconds);

            // let's handle future times..just in case
            if (intDays < 0)
                return string.Format("in {0} days", Math.Abs(intDays));

            if (intHours < 0)
                return string.Format("in {0} hours", Math.Abs(intHours));

            if (intMinutes < 0)
                return string.Format("in {0} minutes", Math.Abs(intMinutes));

            if (intSeconds < 0)
                return string.Format("in {0} seconds", Math.Abs(intSeconds));

            return "a bit";
        }

    }
}
