using MvcCodeFirstProject_Iqbal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirstProject_Iqbal.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllTeacher());
        }

        IEnumerable<Teacher> GetAllTeacher()
        {
            using (TableContext db = new TableContext())
            {
                return db.Teachers.ToList<Teacher>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Teacher teacher = new Teacher();
            if (id != 0)
            {
                using (TableContext db = new TableContext())
                {
                    teacher = db.Teachers.Where(x => x.TeacherID == id).FirstOrDefault<Teacher>();
                }
            }
            return View(teacher);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Teacher teacher)
        {
            try
            {
                if (teacher.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(teacher.ImageUpload.FileName);
                    string extension = Path.GetExtension(teacher.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    teacher.TecherImage = "~/Images/" + fileName;
                    teacher.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
                }
                using (TableContext db = new TableContext())
                {
                    if (teacher.TeacherID == 0)
                    {
                        db.Teachers.Add(teacher);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(teacher).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllTeacher()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (TableContext db = new TableContext())
                {
                    Teacher teacher = db.Teachers.Where(x => x.TeacherID == id).FirstOrDefault<Teacher>();
                    db.Teachers.Remove(teacher);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllTeacher()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}