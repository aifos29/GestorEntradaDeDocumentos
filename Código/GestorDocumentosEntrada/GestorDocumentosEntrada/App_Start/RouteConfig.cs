using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestorDocumentosEntrada
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "LogIn", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PlatformMenu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Menu", action = "platFormMenu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PlatformBossMenu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Menu", action = "platFormBossMenu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdministrativeMenu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Menu", action = "administrativeMenu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdministratorMenu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Menu", action = "administratorMenu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarDocumento",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Procedure", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditarTramite",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Procedure", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BuscarOficio",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Procedure", action = "SearchProcedure", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "VerOficio",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Procedure", action = "AddProcedure", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Correspondencia",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Procedure", action = "dailyProcedure", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProcedureList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Procedure", action = "transferProcedure", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DisplayProcedure",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Procedure", action = "displayProcedure", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UserList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administrator", action = "UserList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateUSer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administrator", action = "CreateUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProcedureType",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administrator", action = "procedureTypes", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddUSer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administrator", action = "AddUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditUSer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administrator", action = "EditUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Statistic",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Reports", action = "Statistic", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Binnacle",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Reports", action = "Binnacle", id = UrlParameter.Optional }
            );
        }
    }
}
