using SH.Entities;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Repository
{
    public interface ISHRepo
    {
        //Student
        int SaveStudent(StudentInfo studentInfo);
        List<StudentInfo> GetAllStudentInfo();
        StudentInfo GetStudentInfoById(int StudentId);
        StudentDocs GetStudentDocByStudentId(string Id);
        //User
        int SaveUser(RegisterUser registerUser);
        RegisterUser UserLogin(string Email, string Password);

        //Course
        int SaveCourse(CourseInfo courseInfo);
        int SaveCourseList(List<CourseInfo> courseInfoList);
        List<CourseInfo> GetCourses(CourseInfoVM courseInfo, out int recordsTotal);
        List<CourseInfo> GetAllCourses();
        CourseInfo GetCourseById(int CourseId);
        IQueryable<CourseInfo> GetAllCoursesRaw(CourseDatatableVM searchQueryVM, string whereCondition, string countCondition);
        int UploadFile(StudentDocs studentDocs);
    }
}
