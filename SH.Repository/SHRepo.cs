using SH.Entities;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace SH.Repository
{
    public class SHRepo : ISHRepo
    {
        private SHContext _ctx;

        public SHRepo(SHContext ctx)
        {
            _ctx = ctx;
        }
        #region Student
        public int SaveStudent(StudentInfo studentInfo)
        {
            int retcode = 0;
            try
            {
                if (studentInfo.StudentId > 0)
                {
                    _ctx.Entry(studentInfo).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    studentInfo = _ctx.StudentInfo.Add(studentInfo);
                }
                 _ctx.SaveChanges();
                retcode = _ctx.StudentInfo.Where(x => x.Cloak == false).Max(i => i.StudentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retcode;
        }
        public List<StudentInfo> GetAllStudentInfo()
        {
            try
            {
                return _ctx.StudentInfo.Where(i => i.Cloak == false ).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentInfo GetStudentInfoById(int StudentId)
        {
            try
            {
                return _ctx.StudentInfo.Where(i => i.Cloak == false && i.StudentId == StudentId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StudentDocs GetStudentDocByStudentId(string Id)
        {
            try
            {
                return _ctx.StudentDocs.Where(i => i.Cloak == false && i.StudentID == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region User
        public int SaveUser(RegisterUser registerUser)
        {
            int retcode = 0;
            try
            {
                if (registerUser.ID > 0)
                {
                    _ctx.Entry(registerUser).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    registerUser = _ctx.RegisterUser.Add(registerUser);
                }
                retcode = _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retcode;
        }
        public RegisterUser UserLogin(string Email, string Password)
        {
            try
            {
                return _ctx.RegisterUser.Where(i => i.Cloak == false && i.Email == Email && i.Password == Password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Course
        public int SaveCourse(CourseInfo courseInfo)
        {
            int retcode = 0;
            try
            {
                if (courseInfo.CourseId > 0)
                {
                    _ctx.Entry(courseInfo).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    courseInfo = _ctx.CourseInfo.Add(courseInfo);
                }
                retcode = _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retcode;
        }
        public int SaveCourseList(List<CourseInfo> courseInfoList)
        {
            int retcode = 0;
            try
            {
                _ctx.CourseInfo.AddRange(courseInfoList);                
                retcode = _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retcode;
        }
        public List<CourseInfo> GetAllCourses()
        {
            try
            {
                return _ctx.CourseInfo.Where(i => i.Cloak == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CourseInfo> GetCourses(CourseInfoVM courseInfo, out int recordsTotal)
        {
            try
            {
                recordsTotal = _ctx.CourseInfo.Where(i => i.Cloak == false).Count();
                if (!string.IsNullOrEmpty(courseInfo.sortColumnName)&& !string.IsNullOrEmpty(courseInfo.sortDirection))
                {
                    if (!string.IsNullOrEmpty(courseInfo.searchValue))
                    {
                        return _ctx.CourseInfo.Where(i => i.Cloak == false).OrderBy(courseInfo.sortColumnName + " " + courseInfo.sortDirection).Where(x => x.CourseName.Contains(courseInfo.searchValue) || x.CourseId.ToString().Contains(courseInfo.searchValue)).ToList();
                    }
                    else
                    {
                        return _ctx.CourseInfo.Where(i => i.Cloak == false).OrderBy(courseInfo.sortColumnName + " " + courseInfo.sortDirection).Skip(courseInfo.skip).Take(courseInfo.pageSize).ToList();
                    }
                }
                return _ctx.CourseInfo.Where(i => i.Cloak == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CourseInfo GetCourseById(int CourseId)
        {
            try
            {
                return _ctx.CourseInfo.Where(i => i.Cloak == false && i.CourseId == CourseId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public IQueryable<CourseInfo> GetAllCoursesRaw(CourseDatatableVM searchQueryVM, string whereCondition, string countCondition)
        {
            try
            {
                string sql = @"SELECT [CourseId]
                                      ,[CourseName]
                                  FROM [StudentHub].[dbo].[CourseInfo]";

                sql += whereCondition;
                string query = string.Format(sql, searchQueryVM.sortColumnName, searchQueryVM.skip, searchQueryVM.pageSize);

                var result = _ctx.Database.SqlQuery<CourseInfo>(query).AsQueryable();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UploadFile(StudentDocs studentDocs)
        {
            int retcode = 0;
            try
            {
                if (studentDocs.Id > 0)
                {
                    var keyDetached = _ctx.Set<StudentDocs>().Local.FirstOrDefault(entry => entry.Id.Equals(studentDocs.Id));
                    if (keyDetached != null)
                    {
                        _ctx.Entry(keyDetached).State = System.Data.Entity.EntityState.Detached;
                    }
                    _ctx.Entry(studentDocs).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    studentDocs = _ctx.StudentDocs.Add(studentDocs);
                }
                retcode = _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retcode;
        }
    }
}
