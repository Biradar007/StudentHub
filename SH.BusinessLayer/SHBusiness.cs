using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SH.Entities;
using SH.Repository;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SH.BusinessLayer
{
    public partial class SHBusiness : ISHBusiness
    {
        public SHBusiness(ISHRepo Repository)
        {
            _repo = Repository;
        }
        private ISHRepo _repo;

        #region Student
        public int SaveStudentInfo(StudentInfoVM studentInfoVM)
        {
            try
            {
                if(studentInfoVM.CourseList != null)                                                        //Check if courses are added by the user
                {                                                                                           //If yes, add the new courses in courses table
                    studentInfoVM.Courses = JsonConvert.SerializeObject(studentInfoVM.CourseList);
                    var AllCourses = GetAllCourses();
                    List<CourseInfo> CourseInfoList = new List<CourseInfo>();
                    var MissingCourse = studentInfoVM.CourseList.Except(AllCourses.Select(x => x.CourseName)).ToList();
                    foreach (var course in MissingCourse)
                    {
                        CourseInfo CourseInfo = new CourseInfo();
                        CourseInfo.CourseId = 0;
                        CourseInfo.CourseName = course;
                        CourseInfoList.Add(CourseInfo);
                    }
                    if (MissingCourse.Count > 0)
                    {
                        var SaveCourses = _repo.SaveCourseList(CourseInfoList);
                    }
                }
                
                return _repo.SaveStudent(Mapper.Map<StudentInfoVM, StudentInfo>(studentInfoVM));            //If no, just save student data in student table
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<StudentInfoVM> GetAllStudentInfo()
        {
            List<StudentInfoVM> StudentsData = Mapper.Map<List<StudentInfo>, List<StudentInfoVM>>(_repo.GetAllStudentInfo());
            return StudentsData;
        }
        public StudentInfoVM GetStudentInfoById(int StudentId)
        {
            StudentInfoVM StudentsData = Mapper.Map<StudentInfo, StudentInfoVM>(_repo.GetStudentInfoById(StudentId));
            if(StudentsData.Courses != null)
            {
                StudentsData.CourseList = JsonConvert.DeserializeObject<string[]>(StudentsData.Courses);
            }
            return StudentsData;
        }

        public int DeleteStudentInfo(int StudentId)
        {
            try
            {
                var StudentData = _repo.GetStudentInfoById(StudentId);
                StudentData.Cloak = true;
                return _repo.SaveStudent(StudentData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentDocsVM GetStudentDocByStudentId(string Id)
        {
            StudentDocsVM EmployeeDocsData = Mapper.Map<StudentDocs, StudentDocsVM>(_repo.GetStudentDocByStudentId(Id));
            return EmployeeDocsData;
        }
        #endregion

        #region User

        public int SaveUser(RegisterUserVM registerUser)
        {
            try
            {
                return _repo.SaveUser(Mapper.Map<RegisterUserVM, RegisterUser>(registerUser));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RegisterUserVM UserLogin(string Email, string Password)
        {
            RegisterUserVM StudentsData = Mapper.Map<RegisterUser, RegisterUserVM>(_repo.UserLogin(Email, Password));
            return StudentsData;
        }
    #endregion

        #region Course
        public int SaveCourse(CourseInfoVM courseInfo)
        {
            try
            {
                return _repo.SaveCourse(Mapper.Map<CourseInfoVM, CourseInfo>(courseInfo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CourseInfoVM> GetAllCourses()
        {
            List<CourseInfoVM> CoursesData = Mapper.Map<List<CourseInfo>, List<CourseInfoVM>>(_repo.GetAllCourses());
            return CoursesData;
        }
        public List<CourseInfoVM> GetCourses(CourseInfoVM courseInfo, out int recordsTotal)
        {
            List<CourseInfoVM> CoursesData = Mapper.Map<List<CourseInfo>, List<CourseInfoVM>>(_repo.GetCourses(courseInfo, out recordsTotal));
            return CoursesData;
        }
        public CourseInfoVM GetCourseById(int CourseId)
        {
            CourseInfoVM CoursesData = Mapper.Map<CourseInfo, CourseInfoVM>(_repo.GetCourseById(CourseId));
            return CoursesData;
        }

        public int DeleteCourseInfo(int CourseId)
        {
            try
            {
                var CourseData = _repo.GetCourseById(CourseId);
                CourseData.Cloak = true;
                return _repo.SaveCourse(CourseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public List<string> GetCountriesFromAPI()                                                   //API to fetch list of countries 
        {
            string Link = "https://api.first.org/data/v1/countries";
            var APIData = new Dictionary<string, object>();
            List<string> CountriesList = new List<string>();
            try
            {
                HttpClient client = new HttpClient();
                string url = string.Empty;
                client.Timeout = TimeSpan.FromMinutes(10);
                url = Link;
                var task = client.GetAsync(url)
                .ContinueWith((taskwithresponse) =>
                {
                    var response = taskwithresponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    APIData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString.Result);
                    if (Convert.ToString(APIData["status"]) == "OK")
                    {
                        var APIRatesData = APIData["data"].ToString();
                        var CountriesDetails = JsonConvert.DeserializeObject<Dictionary<string, object>>(APIRatesData);

                        foreach (var rate in CountriesDetails)
                        {
                            var Country = JsonConvert.DeserializeObject<Dictionary<string, object>>(rate.Value.ToString()).FirstOrDefault();
                            CountriesList.Add(Country.Value.ToString());
                        }
                    }
                });
                task.Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CountriesList;
        }
        public int UploadFile(StudentDocsVM studentDocs)
        {
            try
            {
                return _repo.UploadFile(Mapper.Map<StudentDocsVM, StudentDocs>(studentDocs));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


