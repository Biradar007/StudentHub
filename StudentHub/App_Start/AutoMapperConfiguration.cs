using SH.Entities;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentHub.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StudentInfo, StudentInfoVM>().ReverseMap();
                cfg.CreateMap<CourseInfo, CourseInfoVM>().ReverseMap();

            });
        }
    }
}