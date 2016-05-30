using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MusStore.Models;
using MusStore.Services;
using System.IO;
using EF.Core;
using EF.Data;


namespace MusStore.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
   
        private ITopicRepository _topicRepo;
        private ICompanyRepository _companyRepo;
        private IUnitOfWork _iUnitOfWork;
        // GET: /Home/
        public HomeController(IMailService mail,IUnitOfWork unitOfWork)
        {
            _mail = mail;
          
            //_topicRepo = repository;
            //_companyRepo = compRepo;

            _topicRepo = unitOfWork.Topics;
            _companyRepo = unitOfWork.Companies;
            _iUnitOfWork = unitOfWork;
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
            var topicViewModel = new List<TopicImageViewModel>();
            var topViewModel = new TopicImageViewModel();

            var imageRepo = _iUnitOfWork.Images;
            if (Id == 0)
            {
              foreach (var item in _topicRepo.GetAll())
              {
                
                 topViewModel.Body = item.Body;
                 topViewModel.Title = item.Title;
                 topViewModel.ImagePath= imageRepo.GetAllImagesByTopic(item.Id).ToList();
                 topicViewModel.Add(topViewModel);
              }

            }
            else
            {
             //   topic.Add(_repo.GetTopic(Id));
                var topic = _topicRepo.GetById(Id);
                topViewModel.Body = topic.Body;
                topViewModel.Title = topic.Title;
                
                //search with the topic id to get the path;

                topViewModel.ImagePath = imageRepo.GetAllImagesByTopic(Id).ToList();


                topicViewModel.Add(topViewModel);
               
            }
            return View(topicViewModel);
        }
     

        [HttpGet]
        public ActionResult CompanyEntry()
        {
            return View();
        }

        //[HttpGet]
      
        public ActionResult Menu()
        {
            return PartialView("Menu", GetMenu());
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
            int flag = 0;

            //change this function to add new images in to the new table and 
            //related image id into the topics table below ;
            Guid imageGuid = Guid.NewGuid();
            if (file != null && file.ContentLength > 0)
                try
                {
                   
                    var comp = new Company { CompanyName = company.CompanyName };
                    _companyRepo.Save(comp);
                    
                    //save the passed image;
                    //if (!_companyRepo.GetAll().Any())
                    //{
                        _iUnitOfWork.Commit();
                        flag = 1;
                    //}
                   
                    idCompany = _companyRepo.GetAll().OrderByDescending(p => p.Id).FirstOrDefault().Id;
                    //_topicRepo.GetAll().OrderByDescending(p => p.Id).FirstOrDefault().Id;
                     path = flag==1? Path.Combine(Server.MapPath("~/Content/Images"),
                         "Company" + idCompany + Path.GetExtension(file.FileName)) : Path.Combine(Server.MapPath("~/Content/Images"),
                         "Company" + ++idCompany + Path.GetExtension(file.FileName));

                    file.SaveAs(path);
                  //  path to be save to the database;
                    path = "/Content/Images/Company" +
                           idCompany + Path.GetExtension(file.FileName);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message;
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            var listing = new Topic
            {
                Body = company.Body,
                CompanyId = idCompany,
                Created = DateTime.Now,
             //   isVisible = true,
             //this will need to be retrieved from image table from now on 
             //F
                ImageId = imageGuid,
                Title = company.Title,
            //    ProductCategory = "UnCategorized"
            };

            _topicRepo.Save(listing);

            _iUnitOfWork.Commit();

            var image = new EF.Core.Image
            {
                ImageId = imageGuid,
                ImagePath = path,
                TopicId = _topicRepo.GetTopicByImageId(imageGuid).Id
            };

            var imageRepo = _iUnitOfWork.Images;

            imageRepo.Save(image);

            _iUnitOfWork.Commit();
            //Now add the path to the 

            //redirect to the created company's page
            return RedirectToAction("Index", routeValues: new { id = idCompany });
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


        private CategoryCompany GetMenu()
        {
            List<MusStore.Models.Menu> menu = new List<MusStore.Models.Menu>();
            var topics = _topicRepo.GetAll();
            var companies = _companyRepo.GetAll();
            CategoryCompany displayMenu = new CategoryCompany();
            displayMenu.CompanyCategory = new Dictionary<string, List<MusStore.Models.Menu>>();



            foreach (var item in topics)
            {
                if (item.isVisible)
                {
                    var menuitem = new Models.Menu();
                    menuitem.TopicId = item.Id; //we are assigning topic id here since topic related to that company will be displayed
                    menuitem.CompanyName = companies.Where(p => p.Id == item.CompanyId).FirstOrDefault().CompanyName;
                   //menuitems path is no longer valid it is turned into a guid and 
                    //needs to be retrieved from image table
                    //F
                    // menuitem.Path = item.Path;
                    //
                    menuitem.ProductCategory = item.ProductCategory;
                    //menu.Add(menuitem);

                    if (displayMenu.CompanyCategory.ContainsKey(item.ProductCategory))
                    {

                        displayMenu.CompanyCategory[item.ProductCategory].Add(menuitem);
                    }
                    else
                    {
                        displayMenu.CompanyCategory.Add(item.ProductCategory, new List<MusStore.Models.Menu> { menuitem });

                    }

                }
            }

            return displayMenu;
        }
    }

    
}
