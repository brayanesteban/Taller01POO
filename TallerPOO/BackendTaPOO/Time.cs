namespace BackendTaPOO
{
    public class Time
    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;
        public Time()
        {
            Hour = 0;
            Minutes = 0;
            Seconds = 0;
            Milliseconds = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
            Minutes = 0;
            Seconds = 0;
            Milliseconds = 0;
        }

        public Time(int hour, int minutes)
        {
            Hour = hour;
            Minutes = minutes;
            Seconds = 0;
            Milliseconds = 0;
        }

        public Time(int hour, int minutes, int seconds)
        {
            Hour = hour;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = 0;
        }

        public Time(int hour, int minutes, int seconds, int milliseconds)
        {
            Hour = hour;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }

        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }

        public int Milliseconds
        {
            get => _millisecond;
            set => _millisecond = ValidateMillisecond(value);
        }

        public int Minutes
        {
            get => _minute;
            set => _minute = ValidateMinute(value);
        }

        public int Seconds
        {
            get => _second;
            set => _second = ValidateSecond(value);
        }

        public override string ToString()
        {
            int hour12 = Hour % 12;

            if (hour12 == 0)
                hour12 = 12;

            string period = Hour < 12 ? "AM" : "PM";

            return $"{hour12:D2}:{Minutes:D2}:{Seconds:D2}.{Milliseconds:D3} {period}";

        }
        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour}, is not valid");
            }
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), $"The minute: {minute}, is not valid");
            }
            return minute;
        }

        private int ValidateMillisecond(int millisecond)
        {
           if( millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(millisecond), $"The millisecond {millisecond} is not valid");
            }
            return millisecond ;
        }
        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), $"The Second {second} is not valid");
            }
            return second;
        }
        public int ToMilliseconds()
        {
            return Hour * 3600000 + 
             Minutes * 60000 + 
             Seconds * 1000 + 
             Milliseconds;
        }

        public int ToSeconds()
        {
            return ToMilliseconds() / 1000;
        }

        public int ToMinutes()
        {
            return ToSeconds() / 60;
        }

        public Time Add(Time other)
        {
            int totalMilliseconds = ToMilliseconds() + other.ToMilliseconds();

            int millisecondsPerDay = 24 * 60 * 60 * 1000;

            totalMilliseconds = totalMilliseconds % millisecondsPerDay;

            int hour = totalMilliseconds / 3600000;
            totalMilliseconds %= 3600000;

            int minute = totalMilliseconds / 60000;
            totalMilliseconds %= 60000;

            int second = totalMilliseconds / 1000;
            int millisecond = totalMilliseconds % 1000;

            return new Time(hour, minute, second, millisecond);
        }

        public bool IsOtherDay(Time other)
        {
            return Hour < other.Hour || (Hour == other.Hour && Minutes < other.Minutes) ||
                   (Hour == other.Hour && Minutes == other.Minutes && Seconds < other.Seconds) ||
                   (Hour == other.Hour && Minutes == other.Minutes && Seconds == other.Seconds && Milliseconds < other.Milliseconds);
        }
    }
}


    
