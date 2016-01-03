using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EF.Core;
using EF.Data.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;


namespace EF.Data
{
    public class MessageBoardContext : IdentityDbContext<ApplicationUser>
    {
        public MessageBoardContext()
            : base("abc")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

          //Database.SetInitializer(
          //    new MigrateDatabaseToLatestVersion<MessageBoardContext,MessageBoardMigrationsConfiguration>()
          //    );
            Database.SetInitializer<MessageBoardContext>(new MigrateDatabaseToLatestVersion<MessageBoardContext,Configuration>());
        }

        public DbSet<Topic> Topics { get; set; }
        //public DbSet<Reply> Replies { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}