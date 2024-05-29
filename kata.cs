using System;
using System.Collections.Generic;
using System.Linq;

namespace KataSuez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Measure[] measures = new Measure[]
            {
               new Measure { Timestamp = new DateTime(2019, 10, 01, 10, 14, 11), State = 0 },
               new Measure { Timestamp = new DateTime(2019, 10, 01, 10, 55, 00), State = 1 },
               new Measure { Timestamp = new DateTime(2019, 10, 01, 12, 21, 00), State = 0 },
               new Measure { Timestamp = new DateTime(2019, 10, 01, 13, 14, 12), State = 1 },
               new Measure { Timestamp = new DateTime(2019, 10, 01, 14, 45, 14), State = 0 }
            };

            DateTime start = new DateTime(2019, 10, 1, 11, 0, 0);
            DateTime end = new DateTime(2019, 10, 1, 13, 0, 0);

            TimeSpan runningDuration = GetRunningDurationOnPeriod(measures, start, end);

            Console.WriteLine("res {0}", runningDuration);
        }

        public static TimeSpan GetRunningDurationOnPeriod(Measure[] onOffMeasures, DateTime start, DateTime end)
        {
            var beforeStart = onOffMeasures.LastOrDefault(m => m.Timestamp < start);
            var afterEnd = onOffMeasures.FirstOrDefault(m => m.Timestamp > end);

            var startingMeasures = new Measure[]
            {
                new Measure { Timestamp = start, State = beforeStart?.State ?? 0 },
                new Measure { Timestamp = end, State = afterEnd?.State ?? 0 },
            };

            var filteredMeasure = onOffMeasures
                .Where(m => m.Timestamp >= start && m.Timestamp <= end)
                .Concat(startingMeasures)
                .OrderBy(m => m.Timestamp)
                .ToList();

            return filteredMeasure
                .Select((x, i) => i < filteredMeasure.Count - 1
                ? new { x.State, Duration = filteredMeasure[i + 1].Timestamp - x.Timestamp }
                : new { x.State, Duration = TimeSpan.Zero })
                .Where(x => x.State == 1)
                .Aggregate(TimeSpan.Zero, (total, x) => total + x.Duration);
        }
    }

    public class Measure
    {
        public DateTime Timestamp { get; set; }
        public int State { get; set; }
    }
}
