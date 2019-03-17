using System;
using System.ComponentModel;

namespace SimpleCalc
{
    public class SimpleCalc
    {
        public enum TimeType
        {
            Seconds = 1,
            Hours,
            Days
        }

        public int AddInt(int operand1, int operand2)
        {
            return operand1 + operand2;
        }

        public int SubtractInt(int operand1, int operand2)
        {
            return operand1 - operand2;
            // return AddInt(operand1 * -1, operand2);
        }

        public DateTime AddTime(DateTime dateTime, int increment, TimeType type)
        {
            DateTime result;

            switch (type)
            {
                case TimeType.Seconds:
                    result = dateTime.AddSeconds(increment);
                    break;
                case TimeType.Hours:
                    result = dateTime.AddHours(increment);
                    break;
                case TimeType.Days:
                    result = dateTime.AddDays(increment);
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(type));
            }

            return result;
        }
    }
}
