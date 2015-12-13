using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MusStore.Authentication;
using MusStore.Data;
using Owin;

[assembly: OwinStartup(typeof(MusStore.Startup))]

namespace MusStore
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888


            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new MessageBoardContext()));
                //allow alphanumeric characters in the username
                usermanager.UserValidator=new UserValidator<AppUser>(usermanager);
                {
                  
                }
                


                return usermanager;
            };

        }


      
    }
    
}
