using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MusStore.Data;
using MusStore.Models;
using MusStore.Services;
using System.IO;

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
        //[HttpGet]
        //public ActionResult Index()
        //{

        //    //var topic = _repo.GetTopics()
        //    //    .OrderByDescending(t => t.Created)
        //    //    .Take(25).ToList();
        //   //var topic=new MusStore.Data.Topic();
           
        //   // if (Id == 0 || Id==null)
        //   // {
        //   //      topic = _repo.GetTopics().FirstOrDefault();
        //   // }
        //   // else
        //   // {
        //   //      topic = _repo.GetTopic(Id);  
        //   // }
 
        //   // List<Topic> list1=new List<Topic>();
        //   // list1.Add(topic);
        //    return View(_repo.GetTopics());
        //}
        [HttpGet]
        public ActionResult Index(int Id=0)
        {
            var topic = new List<Topic>();

            if (Id == 0 || Id == null)
            {
                foreach (var item in _repo.GetTopics())
                {
                    topic.Add(item);
                }
            }
            else
            {
                topic.Add(_repo.GetTopic(Id));
               
            }
            return View(topic);
        }
     

        [HttpGet]
        public ActionResult CompanyEntry()
        {
            return View();
        }

        //[HttpGet]
      
        public ActionResult Menu()
        {
            return PartialView("Menu", _repo.GetMenu());
        }
       
      
        [HttpPost]
        public ActionResult CompanyEntry(HttpPostedFileBase file,CompanyTopic company)
        {
            // This needs to save the file, get the path form the topic and save both the topic and the company
            // Here we save the file as well as we have all the information to process 
            // both topics and company data so all these objects need to be formed and save here if not server side errors 
            // should be thrown...
            string path="";
            int idCompany=0;
            if (file != null && file.ContentLength > 0)
                try
                {
                    //  I do not care what name they used for the file itself...
                    //  string path = Path.Combine(Server.MapPath("~/Content/Images"),
                    //  Path.GetFileName(file.FileName));
                    
                    //save the passed image;
                     idCompany = _repo.GetCompanies().OrderByDescending(p => p.Id).FirstOrDefault().Id;
                     path = Path.Combine(Server.MapPath("~/Content/Images"),
                                              "Company"+ ++idCompany+Path.GetExtension(file.FileName));


                    file.SaveAs(path);
                    //path to be save to the database;
                    path = "/Content/Images/Company" +
                           _repo.GetCompanies().OrderByDescending(p => p.Id).FirstOrDefault().Id + Path.GetExtension(file.FileName);

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

          


            var comp = new Company { CompanyName = company.CompanyName};
            _repo.AddCompany(comp);
            _repo.Save();
            var listing = new Topic
            {
                Body = company.Body,
                CompanyId = _repo.GetCompanies().OrderByDescending(p => p.Id).FirstOrDefault().Id,
                Created = DateTime.Now,
                isVisible = true,
                Path = path,
                Title = company.Title
            };
            _repo.AddTopic(listing);

            _repo.Save();

            return View();
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
