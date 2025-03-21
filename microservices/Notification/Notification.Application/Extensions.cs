﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.CQRS;

namespace Notification.Application;

public static class Extensions
{
    public static IServiceCollection AddNotificationApplication(this IServiceCollection services)
    {

        services.AddCQRS(Assembly.GetExecutingAssembly());
        return services;
    }
}