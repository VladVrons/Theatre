﻿using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Struct
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public IUnitOfWork uow;
        public ServiceModule(string connection)
        {
            uow = new EFUnitOfWork(connection);
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
