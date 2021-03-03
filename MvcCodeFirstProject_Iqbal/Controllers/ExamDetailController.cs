using MvcCodeFirstProject_Iqbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirstProject_Iqbal.Controllers
{
    public class ExamDetailController : Controller
    {
        private TableContext db = new TableContext();
        // GET: ExamDetail
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateUpdateEmp()
        {
            var examdata = new ExamDetailDTO()
            {

                ExamDetailList = db.ExamDetails.ToList()
            };
            var traineeList = db.Trainees.ToList();
            ViewBag.TraineeID = new SelectList(traineeList, "TraineeID", "TraineeName");

            return View(examdata);
        }

        [HttpPost]
        public ActionResult CreateUpdateEmp(ExamDetailDTO examDetail)
        {
            if (examDetail.ExamDetailData.ExamDetailID == 0)
            {
                var traineeList = db.Trainees.ToList();
                ViewBag.TraineeID = new SelectList(traineeList, "TraineeID", "TraineeName");
                db.ExamDetails.Add(examDetail.ExamDetailData);
                db.SaveChanges();
            }
            else
            {
                var dataInDb = db.ExamDetails.FirstOrDefault(a => a.ExamDetailID == examDetail.ExamDetailData.ExamDetailID);
                dataInDb.ExamName = examDetail.ExamDetailData.ExamName;
                dataInDb.ExamDate = examDetail.ExamDetailData.ExamDate;
                dataInDb.MCQ = examDetail.ExamDetailData.MCQ;
                dataInDb.Evidence = examDetail.ExamDetailData.Evidence;
                dataInDb.TraineeID = examDetail.ExamDetailData.TraineeID;
                db.SaveChanges();
            }

            return RedirectToAction("CreateUpdateEmp");
        }

        public ActionResult Delete(int id)
        {
            var traineeList = db.Trainees.ToList();
            ViewBag.TraineeID = new SelectList(traineeList, "TraineeID", "TraineeName");
            var dataForDelete = db.ExamDetails.FirstOrDefault(a => a.ExamDetailID == id);
            db.ExamDetails.Remove(dataForDelete);
            db.SaveChanges();
            return RedirectToAction("CreateUpdateEmp");
        }

        public ActionResult Edit(int id)
        {
            var examdata = new ExamDetailDTO()
            {


                ExamDetailList = db.ExamDetails.ToList(),
                ExamDetailData = db.ExamDetails.FirstOrDefault(a => a.ExamDetailID == id)
            };
            var traineeList = db.Trainees.ToList();
            ViewBag.TraineeID = new SelectList(traineeList, "TraineeID", "TraineeName");

            return View("CreateUpdateEmp", examdata);
        }

    }
}