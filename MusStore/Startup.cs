using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MusStore.Startup))]
namespace MusStore
{
    public  partial class Startup
    {
        public static Func<UserManager<ApplicationUser>> UserManagerFactory { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new MessageBoardContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<ApplicationUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };
        }
    }
}