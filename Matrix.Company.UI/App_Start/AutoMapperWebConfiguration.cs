using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Matrix.Company.DomainClasses;
using Matrix.Company.ViewModel;
using Matrix.Company.ViewModel.Account;

namespace Matrix.Company.UI.App_Start
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureWebLinkMapping();
        }

        private static void ConfigureWebLinkMapping()
        {
            Mapper.CreateMap<Weblink, WebLinkViewModel>();
            Mapper.CreateMap<User, RegisterViewModel>();
            //Mapper.CreateMap<User, LoginViewModel>();
            //Mapper.CreateMap<User, ChangePasswordViewModel>();
            //Mapper.CreateMap<User, UserProfileViewModel>();
        }
    }
}