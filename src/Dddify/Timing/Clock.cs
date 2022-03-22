using Dddify.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Dddify.Timing
{
    public class Clock : IClock, ITransientDependency
    {
        private readonly ClockOptions _options;

        public Clock(IOptions<ClockOptions> options)
        {
            _options = options.Value;
        }

        public virtual DateTime Now => _options.DateTimeKind == DateTimeKind.Utc ? DateTime.UtcNow : DateTime.Now;

        public virtual DateTimeKind Kind => _options.DateTimeKind;

        public virtual bool SupportsMultipleTimezone => _options.DateTimeKind == DateTimeKind.Utc;

        public virtual DateTime Normalize(DateTime dateTime)
        {
            if (Kind == DateTimeKind.Unspecified || Kind == dateTime.Kind)
            {
                return dateTime;
            }

            if (Kind == DateTimeKind.Local && dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime.ToLocalTime();
            }

            if (Kind == DateTimeKind.Utc && dateTime.Kind == DateTimeKind.Local)
            {
                return dateTime.ToUniversalTime();
            }

            return DateTime.SpecifyKind(dateTime, Kind);
        }
    }
}


