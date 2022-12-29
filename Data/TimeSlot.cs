using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeService.Data
{
    public class TimeSlot
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeSlot(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public bool IsWithinTimeSlot(DateTime currentTime)
        {
            // Check if the current time is within the specified time slot
            if (currentTime.TimeOfDay >= StartTime.TimeOfDay && currentTime.TimeOfDay <= EndTime.TimeOfDay)
            {
                // Check if the current day is a weekday (Monday to Friday)
                if (currentTime.DayOfWeek >= DayOfWeek.Monday && currentTime.DayOfWeek <= DayOfWeek.Friday)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
