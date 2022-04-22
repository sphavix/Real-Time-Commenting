using PusherServer;
using Real_Time_Commenting.Models;
using Real_Time_Commenting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Real_Time_Commenting.Controllers
{
    public class HomeController : Controller
    {
        CaseDbContext db = new CaseDbContext();
        public ActionResult Index()
        {
            return View(GetAllCases().AsQueryable());
        }

        public List<CaseViewModel> GetAllCases()
        {
            using(CaseDbContext context = new CaseDbContext())
            {
                var cases = context.Cases.Select(x => new CaseViewModel
                {
                    CaseID = x.CaseID,
                    ProductName = x.ProductName,
                    Subject = x.Subject,
                    PriorityName = x.Priority.PriorityName,
                    StatusName = x.Status.StatusName,
                    DateCreated = x.DateCreated,
                    Description = x.Description,
                    IsActive = true,
                    IsDeleted = false
                }).ToList();
                return cases;
            }
        }

        public ActionResult Create()
        {
            ViewBag.PriorityID = new SelectList(GetPriotrities(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(GetStatuses(), "StatusID", "StatusName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CaseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new Case()
                    {
                        CaseID = model.CaseID,
                        ProductName = model.ProductName,
                        Subject = model.Subject,
                        PriorityID = model.PriorityID,
                        StatusID = model.StatusID,
                        DateCreated = model.DateCreated,
                        Description = model.Description,
                        IsActive = true,
                        IsDeleted = false
                    };
                    db.Cases.Add(result);
                    db.SaveChanges();
                }
            }catch(Exception e)
            {
                throw e;
            }
            ViewBag.PriorityID = new SelectList(GetPriotrities(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(GetStatuses(), "StatusID", "StatusName");
            return RedirectToAction("Index");

        }
 
        public List<PriorityViewModel> GetPriotrities()
        {
            using(CaseDbContext context = new CaseDbContext())
            {
                var results = context.Priorities.Select(x => new PriorityViewModel
                {
                    PriorityID = x.PriorityID,
                    PriorityName = x.PriorityName
                }).ToList();
                return results;
            }
        }

        public List<StatusViewModel> GetStatuses()
        {
            using(CaseDbContext context = new CaseDbContext())
            {
               var status = context.Statuses.Select(x => new StatusViewModel
               {
                    StatusID = x.StatusID,
                    StatusName = x.StatusName
                }).ToList();
                return status;
            }
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var results = db.Cases.Find(id);
            if(results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        public ActionResult Update(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var results = db.Cases.Find(id);
            if(results == null)
            {
                return HttpNotFound();
            }

            ViewBag.PriorityID = new SelectList(GetPriotrities(), "PriorityID", "PriorityName");
            ViewBag.StatusID = new SelectList(GetStatuses(), "StatusID", "StatusName");
            return View(results);
        }

        [HttpPost]
        public ActionResult Update(Case model)
        {
            try
            {
                var result = db.Cases.FirstOrDefault(x => x.CaseID == model.CaseID);
                if(result != null)
                {
                    result.CaseID = model.CaseID;
                    result.ProductName = model.ProductName;
                    result.Subject = model.Subject;
                    result.PriorityID = model.PriorityID;
                    result.StatusID = model.StatusID;
                    result.DateCreated = model.DateCreated;
                    result.Description = model.Description;
                    result.IsActive = true;
                    result.IsDeleted = false;
                }
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Comment(int? id)
        {
            var comments = db.Comments.Where(x => x.CaseID == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Comment data)
        {
            if (ModelState.IsValid)
            {
                var results = new Comment()
                {
                    CommentID = data.CommentID,
                    CommentDate = DateTime.Now,
                    Description = data.Description,
                    IsActive = true,
                    IsDeleted = false,
                    CaseID = data.CaseID
                };
                db.Comments.Add(results);
                db.SaveChanges();
            }
           
            var options = new PusherOptions();

            options.Cluster = "ap2";
            var pusher = new Pusher("1382424", "f1e6030670967dc5db74", "181acc6bc55c860fe748", options);
            ITriggerResult result = await pusher.TriggerAsync("my-channel", "my-event", data);
            return Content("Success!");
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}