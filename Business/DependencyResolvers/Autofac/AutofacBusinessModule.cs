﻿using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StorManager>().As<IStorService>();
            builder.RegisterType<EfStorDal>().As<IStorDal>();


            builder.RegisterType<AuthorsManager>().As<IAuthorService>();
            builder.RegisterType<EfAuthorDal>().As<IAuthorsDal>();


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

        }
    }
}
