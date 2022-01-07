using BLL.Servises;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
