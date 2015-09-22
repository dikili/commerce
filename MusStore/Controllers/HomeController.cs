﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MusStore.Data;
using MusStore.Models;
using MusStore.Services;

namespace MusStore.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessageBoardRepository _repo;
        //
        // GET: /Home/
        public HomeController(IMailService mail,IMessageBoardRepository repo)
        {
            _mail = mail;
            _repo = repo;
        }
        [HttpGet]
        public ActionResult Index(int? Id)
        {

            //var topic = _repo.GetTopics()
            //    .OrderByDescending(t => t.Created)
            //    .Take(25).ToList();
           var topic=new MusStore.Data.Topic();
           
            if (Id == 0 || Id==null)
            {
                 topic = _repo.GetTopics().FirstOrDefault();
            }
            else
            {
                 topic = _repo.GetTopic(Id);  
            }
 

            return View(topic);
        }
        
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment from {1}{0}Email:{2}{0}Website:{3}{0}",
                Environment.NewLine,
                model.Name,
                model.Email,
                model.Website,
                model.Message);


            if(_mail.SendMail("dikili@outlook.com", "dikili@outlook.com", "subj", msg))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

        public ActionResult MyMessages()
        {
            return View();
        }
    }

    
}
