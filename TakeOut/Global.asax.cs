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
using TakeOut.ViewModels;

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

                    //店铺转换
                    config.CreateMap<Shop, ShopOutPutViewModel>()
                    .ForMember(dest => dest.KeeperName, opt => opt.MapFrom(src => src.Keeper.LogonUser));

                    //产品转换
                    config.CreateMap<Goods, GoodsOutputViewModel>()
                    .ForMember(dest => dest.ShopName, opt => opt.MapFrom(src => src.Shop.Name));

                    //订单
                    config.CreateMap<Order, OrderOutPutViewModel>()
                    .ForMember(dest => dest.OrderUser, opt => opt.MapFrom(src => src.OrderUser.LogonUser))
                    .ForMember(dest => dest.GoodsCnt, opt => opt.MapFrom(src =>src.Goods.Count()));
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
