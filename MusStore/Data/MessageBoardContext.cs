using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusStore.Data
{
    public class MessageBoardContext :DbContext
    {
        public MessageBoardContext()
            : base("abc")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

          //Database.SetInitializer(
          //    new MigrateDatabaseToLatestVersion<MessageBoardContext,MessageBoardMigrationsConfiguration>()
          //    );
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}