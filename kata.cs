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
            Measure[] sortedMeasures = onOffMeasures.OrderBy(m => m.Timestamp).ToArray();
            TimeSpan runningDuration = TimeSpan.Zero;
            DateTime? runningStart = null;

            foreach (var measure in sortedMeasures)
            {
                if (measure.Timestamp < start)
                {
                    runningStart = (measure.State == 1) ? start : null;
                    continue;
                }
                if (measure.Timestamp >= start && measure.Timestamp <= end)
                {
                    if (measure.State == 1)
                    {
                        runningStart = measure.Timestamp;
                    }
                    else if (measure.State == 0 && runningStart.HasValue)
                    {
                        runningDuration += measure.Timestamp - runningStart.Value;
                        runningStart = null;
                    }
                }

                if (measure.Timestamp > end)
                {
                    if (runningStart.HasValue)
                    {
                        runningDuration += end - runningStart.Value;
                    }
                    break;
                }
            }
            return runningDuration;
        }
    }
    public class Measure
    {
        public DateTime Timestamp { get; set; }
        public int State { get; set; }
    }
}