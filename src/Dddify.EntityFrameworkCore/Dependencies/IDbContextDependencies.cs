using Dddify.Guids;
using Dddify.Security.Identity;
using Dddify.Timing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddify.EntityFrameworkCore
{
    public interface IDbContextDependencies
    {
        ICurrentUser CurrentUser { get; }

        IClock Clock { get; }

        IPublisher Publisher { get; }

        IGuidGenerator GuidGenerator { get; }
    }
}
