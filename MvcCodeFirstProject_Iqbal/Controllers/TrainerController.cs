using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCodeFirstProject_Iqbal.Models;

namespace MvcCodeFirstProject_Iqbal.Controllers
{
    public class TrainerController : Controller
    {
        private TableContext db = new TableContext();

        // GET: Trainer
        public ActionResult Index()
        {
            return View(db.Trainers.ToList());
        }

       

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trainer tr)
        {

            if (ModelState.IsValid == true)
            {
                string fileName = Path.GetFileNameWithoutExtension(tr.UploadImage.FileName);
                string extention = Path.GetExtension(tr.UploadImage.FileName);
                HttpPostedFileBase postedFile = tr.UploadImage;
                int length = postedFile.ContentLength;
                if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extention;
                        tr.Picture = "~/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        tr.UploadImage.SaveAs(fileName);
                        db.Trainers.Add(tr);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            TempData["CreateMessage"] = "<script>alert('Data inserted Successfully')</script>";
                            ModelState.Clear();
                            return RedirectToAction("Index", "Trainer");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data not inserted')</script>";
                        }
                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                    }
                }
                else
                {
                    TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                }
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var TraineeRow = db.Trainers.Where(model => model.TrainerID == id).FirstOrDefault();
            Session["Image"] = TraineeRow.Picture;
            return View(TraineeRow);
        }


        [HttpPost]
        public ActionResult Edit(Trainer tr)
        {
            if (ModelState.IsValid == true)
            {
                if (tr.UploadImage != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(tr.UploadImage.FileName);
                    string extention = Path.GetExtension(tr.UploadImage.FileName);
                    HttpPostedFileBase postedFile = tr.UploadImage;
                    int length = postedFile.ContentLength;
                    if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extention;
                            tr.Picture = "~/Images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                            tr.UploadImage.SaveAs(fileName);
                            db.Entry(tr).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                                ModelState.Clear();
                                return RedirectToAction("Index", "Trainer");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                        }
                    }
                    else
                    {
                        TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                    }
                }
                else
                {
                    tr.Picture = Session["Image"].ToString();
                    db.Entry(tr).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Trainer");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                    }
                }
            }
            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id = 0)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get
        public ActionResult Details(int id = 0)
        {
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
