using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices (this IServiceCollection services)
        {
            // 1. register Application services (MediatR setup later in the sprint).

            return services;
        }
    }
}
