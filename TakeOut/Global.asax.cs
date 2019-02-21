using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using TakeOut.BLL.Dto;
using TakeOut.Models;

namespace TakeOut
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static class MappingConfig
        {
            public static void RegisterMaps()
            {
                Mapper.Initialize(config =>
                {
                    config.CreateMap<User, UserInfoOutput>();
                    config.CreateMap<RegistUserInfoInput, User>();
                    config.CreateMap<ShopInfoInput, Shop>();
                    config.CreateMap<GoodsInfoInput, Goods>();
                });
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingConfig.RegisterMaps();
        }
    }
}
