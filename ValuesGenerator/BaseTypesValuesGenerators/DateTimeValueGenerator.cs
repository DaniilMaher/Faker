using System;

namespace ValuesGenerator.BaseTypesValuesGenerators
{
    public class DateTimeValueGenerator : IBaseTypeValueGenerator
    {
        private Random random;

        public DateTimeValueGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            int year = random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = random.Next(1, 12);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            int hour = random.Next(0, 24);
            int minute = random.Next(0, 60);
            int second = random.Next(0, 60);
            int millisecond = random.Next(0, 1000);
            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }
    }
}
