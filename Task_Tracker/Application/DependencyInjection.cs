using Application.Behaviors;
using Application.Mapping.Auth;
using Application.Mapping.Project.IncommingData;
using Application.Mapping.Project.OutgoingData;
using Application.Mapping.Task.IncomingData;
using Application.Mapping.Task.OutgoingData;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices (this IServiceCollection services)
        {
            // 1. register Application services (MediatR setup later in the sprint).
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehaviors(new List<Type> { typeof(LoggingBehavior<,>), typeof(ValidationBehavior<,>) }); });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(cfg => { }, typeof(DisplayTaskMap), typeof(CreateTaskMap),typeof(UpdateTaskMap)
                ,typeof(CreateProjectMap),typeof(DisplayProjectMap),typeof(RegisterUserMap));
            return services;
        }
    }
}
