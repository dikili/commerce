using MusStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusStore.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        private MessageBoardContext _ctx;
        public MessageBoardRepository(MessageBoardContext ctx)
        {
            this._ctx = ctx;
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {

            return _ctx.Topics.Include("Replies");
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _ctx.Replies.Where(r => r.TopicId == topicId);
        }


        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO logging
                return false;
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                _ctx.Topics.Add(new Topic { Body = newTopic.Body, Title = newTopic.Title, Created = DateTime.Now, Path = newTopic.Path, isVisible = true, CompanyId = newTopic.CompanyId,ProductCategory="UnCategorized"});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddCompany(Company newCompany)
        {
            try
            {
                _ctx.Companies.Add(newCompany);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IQueryable<Topic> GetTopics()
        {
            // var ctx=new MessageBoardContext(); this is expensive and this needs to be disposed properly as well.
            return _ctx.Topics;
        }

        public CategoryCompany GetMenu()
        {
            List<Menu> menu=new List<Menu>();
            var topics = _ctx.Topics;
            var companies = _ctx.Companies;
            CategoryCompany displayMenu = new CategoryCompany();
            displayMenu.CompanyCategory = new Dictionary<string, List<Menu>>();

            

            foreach (var item in topics)
            {
                if(item.isVisible)
                {
                    var menuitem = new Menu();
                    menuitem.CompanyId = item.CompanyId;
                    menuitem.CompanyName = companies.Where(p => p.Id == item.CompanyId).FirstOrDefault().CompanyName;
                    menuitem.Path = item.Path;
                    menuitem.ProductCategory = item.ProductCategory;
                    //menu.Add(menuitem);

                    if (displayMenu.CompanyCategory.ContainsKey(item.ProductCategory))
                    {

                        displayMenu.CompanyCategory[item.ProductCategory].Add(menuitem);
                    }
                    else
                    {
                      displayMenu.CompanyCategory.Add(item.ProductCategory,new List<Menu> {menuitem});
                     
                    }

                }
            }

            return displayMenu;
        }

        public Topic GetTopic(int Id)
        {
            // var ctx=new MessageBoardContext(); this is expensive and this needs to be disposed properly as well.
            return _ctx.Topics.Where(p=>p.CompanyId==Id).FirstOrDefault();
        }

        public IQueryable<Company> GetCompanies()
        {
            return _ctx.Companies;
        }

        public Company GetCompany(int Id)
        {
            return _ctx.Companies.FirstOrDefault(p => p.Id == Id);
        }

        public bool AddReply(Reply newReply)
        {
            try
            {
                _ctx.Replies.Add(newReply);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}