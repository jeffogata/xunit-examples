using System;
using System.ComponentModel;
using Xunit;

namespace SimpleCalc.Tests
{
    public class SimpleCalcTests
    {
        [Fact]
        public void AddInt_One_One_Returns_Two()
        {
            // arrange
            var calc = new SimpleCalc();
            var expected = 2;

            // act
            var actual = calc.AddInt(1, 1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(1, -2, 3)]
        public void SubtractInt(int operand1, int operand2, int expected)
        {
            // arrange
            var calc = new SimpleCalc();

            // act
            var actual = calc.SubtractInt(operand1, operand2);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(SimpleCalc_AddTime_TestData))]
        public void AddTime_ClassData(DateTime dateTime, int increment, SimpleCalc.TimeType type, DateTime expected)
        {
            // arrange
            var calc = new SimpleCalc();

            // act
            var actual = calc.AddTime(dateTime, increment, type);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(AddTimeTestData))]
        public void AddTime_MemberData(DateTime dateTime, int increment, SimpleCalc.TimeType type, DateTime expected)
        {
            // arrange
            var calc = new SimpleCalc();

            // act
            var actual = calc.AddTime(dateTime, increment, type);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddTime_InvalidType_Throws_InvalidEnumArgumentException()
        {
            // arrange
            var calc = new SimpleCalc();

            // act, assert
            Assert.Throws<InvalidEnumArgumentException>(() => calc.AddTime(DateTime.Now, 1, 0));
        }

        public static TheoryData<DateTime, int, SimpleCalc.TimeType, DateTime> AddTimeTestData
        {
            get
            {
                return new TheoryData<DateTime, int, SimpleCalc.TimeType, DateTime>
                {
                    { DateTime.Parse("2019-03-01 15:50"), -1, SimpleCalc.TimeType.Days, DateTime.Parse("2019-02-28 15:50") },
                    { DateTime.Parse("2019-03-01 15:50"), 10, SimpleCalc.TimeType.Hours, DateTime.Parse("2019-03-02 1:50") },
                    { DateTime.Parse("2019-03-01 15:50:55"), 50, SimpleCalc.TimeType.Seconds, DateTime.Parse("2019-03-01 15:51:45") }
                };
            }
        }
    }
}
