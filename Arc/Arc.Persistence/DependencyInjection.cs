﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Persistence
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddPersistence(this ContainerBuilder container)
        {
            container.RegisterType<TestUserDbContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return container;
        }
    }
}