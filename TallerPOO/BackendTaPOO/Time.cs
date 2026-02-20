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
            return $"{Hour:D2}:{Minutes:D2}:{Seconds:D2}.{Milliseconds:D3}";
        }
        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), "Hour must be between 0 and 23.");
            }
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), "Minute must be between 0 and 59.");
            }
            return minute;
        }

        private int ValidateMillisecond(int millisecond)
        {
           if( millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(millisecond), "Millisecond must be between 0 and 999.");
            }
            return millisecond ;
        }
        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), "Second must be between 0 and 59.");
            }
            return second;
        }
    }
}


    
