namespace Tests
{
    internal class DateTimeCreator
    {
        internal static List<DateTime> GetMoreThan60TaxDateTimes()
        {
            return new List<DateTime>()
            {
                new DateTime(2013, 9, 10, 6, 0, 0),
                new DateTime(2013, 9, 10, 6, 30, 0),
                new DateTime(2013, 9, 10, 6, 45, 0),
                new DateTime(2013, 9, 10, 7, 0, 0),
                new DateTime(2013, 9, 10, 7, 40, 0),
                new DateTime(2013, 9, 10, 8, 50, 0),
                new DateTime(2013, 9, 10, 9, 10, 0),
                new DateTime(2013, 9, 10, 9, 30, 0),
                new DateTime(2013, 9, 10, 9, 50, 0),
                new DateTime(2013, 9, 10, 10, 10, 0),
                new DateTime(2013, 9, 10, 10, 30, 0),
                new DateTime(2013, 9, 10, 10, 50, 0),
                new DateTime(2013, 9, 10, 11, 30, 0),
                new DateTime(2013, 9, 10, 11, 50, 0),
                new DateTime(2013, 9, 10, 12, 10, 0),
                new DateTime(2013, 9, 10, 12, 30, 0),
                new DateTime(2013, 9, 10, 12, 50, 0),
                new DateTime(2013, 9, 10, 13, 10, 0),
                new DateTime(2013, 9, 10, 13, 30, 0),
                new DateTime(2013, 9, 10, 13, 50, 0),
                new DateTime(2013, 9, 10, 14, 10, 0),
                new DateTime(2013, 9, 10, 14, 30, 0),
                new DateTime(2013, 9, 10, 14, 50, 0),
                new DateTime(2013, 9, 10, 15, 0, 0),
                new DateTime(2013, 9, 10, 15, 20, 0),
                new DateTime(2013, 9, 10, 15, 40, 0),
                new DateTime(2013, 9, 10, 16, 0, 0),
                new DateTime(2013, 9, 10, 16, 20, 0),
                new DateTime(2013, 9, 10, 16, 40, 0),
                new DateTime(2013, 9, 10, 17, 0, 0),
                new DateTime(2013, 9, 10, 17, 20, 0),
                new DateTime(2013, 9, 10, 17, 40, 0),
                new DateTime(2013, 9, 10, 18, 0, 0),
                new DateTime(2013, 9, 10, 18, 30, 0),
                new DateTime(2013, 9, 10, 19, 0, 0),
                new DateTime(2013, 9, 10, 19, 30, 0),
                new DateTime(2013, 9, 10, 20, 0, 0),
                new DateTime(2013, 9, 10, 20, 30, 0),
            };

        }

        internal static List<DateTime> GetLessThan60TaxDateTimes()
        {
            return new List<DateTime>()
            {
                new DateTime(2013, 9, 11, 6, 0, 0),
                new DateTime(2013, 9, 11, 6, 30, 0),

                new DateTime(2013, 9, 11, 8, 30, 0),
                new DateTime(2013, 9, 11, 14, 45, 0),
                new DateTime(2013, 9, 11, 16, 0, 0),
            };

        }
    }
}
