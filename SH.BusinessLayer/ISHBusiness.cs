using SH.Entities;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SH.BusinessLayer
{
    public interface ISHBusiness
    {
        //Student
        int SaveStudentInfo(StudentInfoVM employeeViewModel);
        List<StudentInfoVM> GetAllStudentInfo();
        StudentInfoVM GetStudentInfoById(int StudentId);
        int DeleteStudentInfo(int StudentId);
        List<string> GetCountriesFromAPI();
        StudentDocsVM GetStudentDocByStudentId(string Id);

        //User
        int SaveUser(RegisterUserVM registerUser);
        RegisterUserVM UserLogin( string Email, string Password);

        //Course
        int SaveCourse(CourseInfoVM courseInfo);
        List<CourseInfoVM> GetAllCourses();
        List<CourseInfoVM> GetCourses(CourseInfoVM courseInfo, out int recordsTotal);
        CourseInfoVM GetCourseById(int CourseId);
        int DeleteCourseInfo(int CourseId);
        int UploadFile(StudentDocsVM studentDocs);
        List<LocationVM> Location();
    }
}
