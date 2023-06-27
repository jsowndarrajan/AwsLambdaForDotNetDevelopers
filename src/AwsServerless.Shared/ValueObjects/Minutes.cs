using System.ComponentModel;

namespace AwsServerless.Shared.ValueObjects
{
    public record Minutes
    {
        private readonly int _minutes;

        public Minutes(int minutes)
        {
            if (minutes < 0 || minutes > 15)
            {
                throw new InvalidEnumArgumentException("Lambda timeout should be greater than 0 and less than 15 minutes");
            }

            _minutes = minutes;
        }

        public static implicit operator Minutes(int minutes)
        {
            return new Minutes(minutes);
        }

        public int ToMilliseconds()
        {
            return _minutes * 60 * 1000;
        }

        public override string ToString()
        {
            return $"{_minutes} minute(s)";
        }
    }
}