using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MusStore.Data
{
    public class MessageBoardMigrationsConfiguration : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);
            if (context.Companies.Count() < 5)
            {

                var company = new Company()
                {
                    CompanyName = "company1seed"
                };
                context.Companies.Add(company);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
//#if DEBUG
                //if (context.Topics.Count() == 0)
                //{
                //    var topic = new Topic()
                //    {
                //        Title = "i love mvc",
                //        Created = DateTime.Now,
                //        Body = "i love asp.net mvc and i want every one to know",
                //        //Replies = new List<Reply>()
                //        //{

                //        //    new Reply()
                //        //    {
                //        //        Body = "i love it too",
                //        //        Create = DateTime.Now
                //        //    },
                //        //    new Reply()
                //        //    {
                //        //        Body = "i need to learn this now",
                //        //        Create = DateTime.Now
                //        //    },
                //        //    new Reply()
                //        //    {
                //        //        Body = "is this an alternative to webforms",
                //        //        Create = DateTime.Now
                //        //    },
                //        //    new Reply()
                //        //    {
                //        //        Body = "fcku mvc",
                //        //        Create = DateTime.Now
                //        //    }
                //        //}


                //    };


                //     var another = new Topic()
                //    {
                //        Title = "hello america",
                //        Created = DateTime.Now,
                //        Body = "i want to go to america",
                //        //Replies = new List<Reply>()
                //        //{

                //        //    new Reply()
                //        //    {
                //        //        Body = "america is golden",
                //        //        Create = DateTime.Now
                //        //    },
                //        //    new Reply()
                //        //    {
                //        //        Body = "if you go america you never come back",
                //        //        Create = DateTime.Now
                //        //    }

                //        //}


                //    };

                //    //context.Topics.Add(topic);
                //    //context.Topics.Add(another);

                //    //try
                //    //{
                //    //    context.SaveChanges();
                //    //}
                //    //catch (Exception ex)
                //    //{
                //    //    var msg = ex.Message;
                //    //}


                //}
//#endif
            }
        }
    }
}
