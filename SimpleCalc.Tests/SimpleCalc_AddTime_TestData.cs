using System;
using Xunit;

namespace SimpleCalc.Tests
{
    public class SimpleCalc_AddTime_TestData : TheoryData<DateTime, int, SimpleCalc.TimeType, DateTime>
    {
        public SimpleCalc_AddTime_TestData()
        {
            Add(DateTime.Parse("2019-03-01 15:50"), -1, SimpleCalc.TimeType.Days, DateTime.Parse("2019-02-28 15:50"));
            Add(DateTime.Parse("2019-03-01 15:50"), 10, SimpleCalc.TimeType.Hours, DateTime.Parse("2019-03-02 1:50"));
            Add(DateTime.Parse("2019-03-01 15:50:55"), 50, SimpleCalc.TimeType.Seconds, DateTime.Parse("2019-03-01 15:51:45"));
        }
    }
}
