using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Helpers
{
    public class ScheduleSlot
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
    public static class ScheduleHelper
    {
        public static List<ScheduleSlot> ParseSchedule(string schedule)
        {
            var slots = new List<ScheduleSlot>();
            if (string.IsNullOrWhiteSpace(schedule)) return slots;
            string[] entries = schedule.Split(';');
            foreach (var entry in entries)
            {
                var trimmed = entry.Trim();
                if (string.IsNullOrEmpty(trimmed)) continue;

                string[] parts = trimmed.Split(' ');
                if (parts.Length != 2) continue;

                DayOfWeek day;
                try
                {
                    day = ParseDay(parts[0]);
                }
                catch
                {
                    continue;
                }

                string[] timeRange = parts[1].Split('-');
                if (timeRange.Length != 2) continue;

                if (TimeSpan.TryParse(timeRange[0], out TimeSpan start) && TimeSpan.TryParse(timeRange[1], out TimeSpan end))
                {
                    slots.Add(new ScheduleSlot
                    {
                        Day = day,
                        StartTime = start,
                        EndTime = end
                    });
                }
            }
            return slots;
        }

        public static bool IsTimeOverLap(TimeSpan start1, TimeSpan end1, TimeSpan start2, TimeSpan end2)
        {
            return start1 < end2 && start2 < end1;
        }
        public static bool IsScheduleOverlap(List<ScheduleSlot> list1, List<ScheduleSlot> list2)
        {
            foreach (var slot1 in list1)
            {
                foreach (var slot2 in list2)
                {
                    if (slot1.Day == slot2.Day &&
                        IsTimeOverLap(slot1.StartTime, slot1.EndTime, slot2.StartTime, slot2.EndTime))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static DayOfWeek ParseDay(string dayAbbr)
        {
            switch (dayAbbr.ToLower())
            {
                case "mon": return DayOfWeek.Monday;
                case "tue": return DayOfWeek.Tuesday;
                case "wed": return DayOfWeek.Wednesday;
                case "thu": return DayOfWeek.Thursday;
                case "fri": return DayOfWeek.Friday;
                case "sat": return DayOfWeek.Saturday;
                case "sun": return DayOfWeek.Sunday;
                default:
                    throw new ArgumentException("Invalid day abbreviation: " + dayAbbr);
            }
        }
    }
}
