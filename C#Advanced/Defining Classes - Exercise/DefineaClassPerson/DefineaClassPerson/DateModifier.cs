using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class DateModifier
    {
        public static int GetDifference(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            TimeSpan diff = dateOne - dateTwo;
            return diff.Days;
        }
    }
}
