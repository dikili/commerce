using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using Ninject.Web.Mvc;


namespace MusStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MusicStoreEntities>());
          // System.Data.Entity.Database.SetInitializer(new MusStore.Models.SampleData());
            //Database.SetInitializer<MusicStoreEntities>(new SampleData());
            //Database.SetInitializer<MessageBoardContext>(new CreateDatabaseIfNotExists<MessageBoardContext>());
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
         
        }
    }
}