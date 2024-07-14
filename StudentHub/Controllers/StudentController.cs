using SH.BusinessLayer;
using SH.Entities;
using SH.Repository;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentHub.Controllers
{
    public class StudentController : BaseController
    {

        private readonly ISHBusiness _ISBiz;
        private readonly ISHRepo _ISrepo;
        public StudentController(ISHRepo repo, ISHBusiness biz) : base(repo, biz)
        {
            _ISrepo = repo;
            _ISBiz = biz;
        }

        //Add Student
        public ActionResult AddStudentInfo()                                            //Form to add student
        {
            ViewBag.Message = "Add Student Information";
            StudentInfoVM studentInfoVM = new StudentInfoVM();
            TempData["AllCountries"] = GetAllCountries().ConvertAll(x =>                //Get countries through api
            {
                return new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.ToString(),
                };
            });
            TempData["AllCourses"] = Biz.GetAllCourses().ConvertAll(x =>                //Get all courses from DB
            {
                return new SelectListItem()
                {
                    Text = x.CourseName.ToString(),
                    Value = x.CourseName.ToString(),
                };
            });
            TempData["AllStates"] = Biz.Location().ConvertAll(x =>                //Get all courses from DB
            {
                return new SelectListItem()
                {
                    Text = x.States.ToString(),
                    Value = x.States.ToString(),
                };
            });
            var Location = Biz.Location().Where(x => x.States == "California").ToList();
            List<string> Cities = new List<string>();
            if (Location.Count != 0)
            {
                Cities = Location.FirstOrDefault().Cities;
            }
            else
            {
                Cities.Add("Please select state first");
            }
            TempData["AllCities"] = Cities.ConvertAll(x =>                //Get all courses from DB
            {
                return new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.ToString(),
                };
            });
            return View("~/Views/Student/AddStudent.cshtml", studentInfoVM);   //Return partial view
            //return PartialView("~/Views/Student/_EditStudent.cshtml", studentInfoVM);   //Return partial view
        }
        public JsonResult GetCities(string State)
        {
            var Location = Biz.Location().Where(x => x.States == State).ToList();
            List<string> Cities = new List<string>();
            List<SelectListItem> DDCities = new List<SelectListItem>();
            if (Location.Count != 0)
            {
                Cities = Location.FirstOrDefault().Cities;
            }
            else
            {
                Cities.Add("Please select state first");
            }
            DDCities.AddRange(Cities.Select(x => new SelectListItem() { Text = x, Value = x }).ToList());
            return Json(new SelectList(DDCities, "Value", "Text"));
        }

        [HttpPost]
        public ActionResult AddStudent(HttpPostedFileBase file, StudentInfoVM studentInfoVM)                  //Save and update student data
        {
            var SaveStudentData = Biz.SaveStudentInfo(studentInfoVM);
            int ID = studentInfoVM.StudentId == 0 ? SaveStudentData : studentInfoVM.StudentId;
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Models"), _FileName);
                    file.SaveAs(_path);
                    var StudentDocsData = Biz.GetStudentDocByStudentId(ID.ToString());
                    if (StudentDocsData != null)
                    {
                        StudentDocsData.FileName = Path.GetFileName(file.FileName);
                        StudentDocsData.FilePath = Path.Combine(Server.MapPath("~/Models"), _FileName);
                        StudentDocsData.FileType = System.IO.Path.GetExtension(_FileName);
                        var saveDoc = Biz.UploadFile(StudentDocsData);
                    }
                    else
                    {
                        StudentDocsVM StudentProfilePhoto = new StudentDocsVM();
                        StudentProfilePhoto.StudentID = ID.ToString();
                        StudentProfilePhoto.FileName = Path.GetFileName(file.FileName);
                        StudentProfilePhoto.FilePath = Path.Combine(Server.MapPath("~/Models"), _FileName);
                        StudentProfilePhoto.FileType = System.IO.Path.GetExtension(_FileName);
                        var saveDoc = Biz.UploadFile(StudentProfilePhoto);
                    }
                }
            }
            return RedirectToAction("StudentList");
        }
        public ActionResult EditStudent(int StudentId)                                  //form to modify student data
        {
            StudentInfoVM studentData = Biz.GetStudentInfoById(StudentId);
            TempData["AllCountries"] = GetAllCountries().ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.ToString(),
                };
            });
            TempData["AllCourses"] = Biz.GetAllCourses().ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.CourseName.ToString(),
                    Value = x.CourseName.ToString(),
                };
            });
            TempData["AllStates"] = Biz.Location().ConvertAll(x =>                //Get all courses from DB
            {
                return new SelectListItem()
                {
                    Text = x.States.ToString(),
                    Value = x.States.ToString(),
                };
            });
            var Location = Biz.Location().Where(x => x.States == studentData.State).ToList();
            List<string> Cities = new List<string>();
            if (Location.Count != 0)
            {
                Cities = Location.FirstOrDefault().Cities;
            }
            else
            {
                Cities.Add("Please select state first");
            }
            TempData["AllCities"] = Cities.ConvertAll(x =>                //Get all courses from DB
            {
                return new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.ToString(),
                };
            });
            ViewBag.Message = "Edit Student Information";
            //return PartialView("~/Views/Student/_EditStudent.cshtml", studentData);
            return View("~/Views/Student/AddStudent.cshtml", studentData);   //Return partial view
        }
        public ActionResult StudentList()                                               //List student data
        {
            List<StudentInfoVM> studentList = Biz.GetAllStudentInfo();
            return View(studentList);
        }
        public ActionResult DeleteStudent(int StudentId)                                //Delete student data
        {
            int studentList = Biz.DeleteStudentInfo(StudentId);
            return RedirectToAction("StudentList");
        }
        public ActionResult StudentDetails(int StudentId)                               //Student data details
        {
            var studentData = Biz.GetStudentInfoById(StudentId);
            var StudentDocsData = Biz.GetStudentDocByStudentId(StudentId.ToString());
            if (StudentDocsData != null)
            {
                studentData.ImgPath = StudentDocsData.FilePath;
            }
            return PartialView("~/Views/Student/_StudentDetails.cshtml", studentData);
        }
        public List<string> GetAllCountries()                                           //Fetch countries from api
        {
            var studentData = Biz.GetCountriesFromAPI().OrderBy(x => x).ToList();
            return studentData;
        }
        public void TopKFrequent()
        {
            char[,] board = {{'1','2','.','.','3','.','.','.','.'},
                             {'4','.','.','5','.','.','.','.','.'},
                             {'.','9','8','.','.','.','.','.','3'},
                             {'5','.','.','.','6','.','.','.','4'},
                             {'.','.','.','8','.','3','.','.','5'},
                             {'7','.','.','.','2','.','.','.','6'},
                             {'.','.','.','.','.','.','2','.','.'},
                             {'.','.','.','4','1','9','.','.','8'},
                             { '.','.','.','.','8','.','.','7','9'}};
            //HashSet<int> numSet = new HashSet<int>(nums);
            //int longest = 0;

            //foreach (int n in numSet)
            //{
            //    if (!numSet.Contains(n - 1))
            //    {
            //        int length = 1;
            //        while (numSet.Contains(n + length))
            //        {
            //            length++;
            //        }
            //        longest = Math.Max(length, longest);
            //    }
            //}
        }
    }
}