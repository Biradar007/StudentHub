using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SH.BusinessLayer;
using SH.Repository;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentHub.Controllers
{
    public class CourseController : BaseController
    {

        private readonly ISHBusiness _ISBiz;
        private readonly ISHRepo _ISrepo;
        public CourseController(ISHRepo repo, ISHBusiness biz) : base(repo, biz)
        {
            _ISrepo = repo;
            _ISBiz = biz;
        }

        public ActionResult AddCourseInfo()                                                  //Form to add course data
        {
            CourseInfoVM courseInfoVM = new CourseInfoVM();
            return PartialView("~/Views/Course/_EditCourse.cshtml", courseInfoVM);
        }
        [HttpPost]
        public ActionResult AddCourse(CourseInfoVM courseInfoVM)                             //Save and update course data
        {
            var SaveStudentData = Biz.SaveCourse(courseInfoVM);
            return RedirectToAction("CourseList");
        }
        public ActionResult EditCourse(int CourseId)                                         //Form to modify course data
        {
            CourseInfoVM CourseData = Biz.GetCourseById(CourseId);
            return PartialView("~/Views/Course/_EditCourse.cshtml", CourseData);
        }
        public ActionResult CourseList()                                                     //List course data
        {
            return View();
        }
        public int DeleteCourse(int CourseId)                                               //Delete course data
        {
            int courseList = Biz.DeleteCourseInfo(CourseId);
            return courseList;
        }
        [HttpPost]
        public ActionResult ListAllData(CourseInfoVM Filter)
        {
            //Find paging start
            Filter.start = Request.Form.GetValues("start").FirstOrDefault();
            //jQuery DataTables Param
            Filter.draw = Request.Form.GetValues("draw").FirstOrDefault();
            //Find paging info        
            Filter.length = Request.Form.GetValues("length").FirstOrDefault();
            //Find order columns info
            Filter.sortColumnName = Request.Form.GetValues("columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]").FirstOrDefault();
            Filter.sortDirection = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //find search columns info
            Filter.searchValue = Request.Form.GetValues("search[value]")[0];
            //var search = searchKeyword.Trim();

            Filter.pageSize = Filter.length != null ? Convert.ToInt32(Filter.length) : 0;
            Filter.skip = Filter.start != null ? Convert.ToInt16(Filter.start) : 0;
            var courseList = Biz.GetCourses(Filter, out int recordsTotal)/*(Filter)*/;
            return Json(new { draw = Filter.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = courseList },
                JsonRequestBehavior.AllowGet);
        }
    }
}