using Dddify.Guids;
using Dddify.Timing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dddify.DependencyInjection
{
    public class DddifyBuilder : IDddifyBuilder
    {
        public IServiceCollection Services { get; }

        public DddifyBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public SequentialGuidType SequentialGuidType
        {
            set
            {
                Services.Configure<SequentialGuidGeneratorOptions>(x => x.SequentialGuidType = value);
            }
        }

        public DateTimeKind DateTimeKind
        {
            set
            {
                Services.Configure<ClockOptions>(x => x.DateTimeKind = value);
            }
        }
    }
}
