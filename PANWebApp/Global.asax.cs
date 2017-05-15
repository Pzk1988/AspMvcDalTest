using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AutoMapper;
using PANWebApp.DAL.DTO;
using PANWebApp.Models;

namespace PANWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static MvcApplication()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDTO, RegisterViewModel>();
                cfg.CreateMap<RegisterViewModel, UserDTO>();
                cfg.CreateMap<AuthorDTO, AuthorViewModel>();
                cfg.CreateMap<AuthorViewModel, AuthorDTO>();
                cfg.CreateMap<AuthorDTO, AuthorDetailsViewModel>();
                cfg.CreateMap<AuthorDetailsViewModel, AuthorDTO>();
                cfg.CreateMap<BookDTO, BookViewModel>();
                cfg.CreateMap<BookViewModel, BookDTO>();
                cfg.CreateMap<BookDTO, BookDetailsViewModel>();
                cfg.CreateMap<BookDetailsViewModel, BookDTO>();

            });
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        FormsAuthenticationTicket formsAuthenticationTicket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

                        if (formsAuthenticationTicket != null)
                        {
                            string username = formsAuthenticationTicket.Name;

                            //Let us set the Pricipal with our user specific details
                            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                                new System.Security.Principal.GenericIdentity(username, "Forms"), new[] { "User" });
                        }
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}
