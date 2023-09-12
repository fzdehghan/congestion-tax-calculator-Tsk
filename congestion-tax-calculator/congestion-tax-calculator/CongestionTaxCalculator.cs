using congestion.calculator;

namespace CongestionCalculator
{
    public class CongestionTaxCalculator
    {
        private const decimal MaxTollInOneDay = 60;
        private const int TimeWindowInMinutes = 60;

        public decimal GetTax(Vehicle vehicle, List<DateTime> dateTimes)
        {
            var groupedByDay = dateTimes.GroupBy(dt => dt.Date).Select(group => group.ToList()).ToList();

            return groupedByDay.AsParallel()
                .Select(d => GetTaxInOneDay(vehicle, d))
                .Sum();
        }

        private decimal GetTaxInOneDay(Vehicle vehicle, List<DateTime> dates)
        {
            decimal response = 0;

            if (DatesHasNoValue(dates))
                return response;

            var dateTimeGroups = CreateDateTimeGroupsInTimeWindow(dates.ToList(), TimeWindowInMinutes);

            foreach (var dateTimeGroup in dateTimeGroups)
            {
                response += GetTaxInOneHour(vehicle, dateTimeGroup);

                if (response >= MaxTollInOneDay)
                    return MaxTollInOneDay;
            }

            return response;
        }

        private List<List<DateTime>> CreateDateTimeGroupsInTimeWindow(List<DateTime> dateTimes, int timeWindowInMinutes)
        {
            dateTimes.Sort();

            var timeWindow = TimeSpan.FromMinutes(timeWindowInMinutes);
            var result = new List<List<DateTime>>();
            var currentGroup = new List<DateTime> { dateTimes[0] };
            var currentTime = dateTimes[0];
            var dateTimesCount = dateTimes.Count;
            if (dateTimesCount == 1) 
            {
                result.Add(currentGroup);
            }

            for (int i = 1; i < dateTimesCount; i++)
            {
                var dt = dateTimes[i];

                if ((dt - currentTime) < timeWindow)
                {
                    currentGroup.Add(dt);
                }
                else
                {
                    result.Add(currentGroup);
                    currentGroup = new List<DateTime> { dt };
                    currentTime = dt;

                    
                }
                if (i == dateTimesCount - 1)
                    result.Add(currentGroup);
            }

            return result;
        }

        private decimal GetTaxInOneHour(Vehicle vehicle, List<DateTime> dates)
        {
            decimal response = 0;

            if (DatesHasNoValue(dates))
                return response;

            foreach (var date in dates)
            {
                decimal nextFee = GetTollFee(date, vehicle);
                response = Math.Max(response, nextFee);
            }

            return response;
        }

        private bool DatesHasNoValue(List<DateTime> dates)
        {
            return dates == null || dates.Count == 0;
        }

        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;
            string vehicleType = vehicle.GetVehicleType();
            return Enum.IsDefined(typeof(TollFreeVehicles), vehicleType);
        }

        private decimal GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute >= 0 && minute <= 29) return 8;
            else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
            else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
            else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
            else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
            else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
            else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
            else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
            else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
            else return 0;
        }

        private bool IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                return (month == 1 && day == 1) ||
                       (month == 3 && (day == 28 || day == 29)) ||
                       (month == 4 && (day == 1 || day == 30)) ||
                       (month == 5 && (day == 1 || day == 8 || day == 9)) ||
                       (month == 6 && (day == 5 || day == 6 || day == 21)) ||
                       (month == 7) ||
                       (month == 11 && day == 1) ||
                       (month == 12 && (day == 24 || day == 25 || day == 26 || day == 31));
            }

            return false;
        }

        private enum TollFreeVehicles
        {
            Motorcycle,
            Tractor,
            Emergency,
            Diplomat,
            Foreign,
            Military
        }
    }
}
