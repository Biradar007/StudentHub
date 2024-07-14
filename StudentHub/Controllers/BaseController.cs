using SH.BusinessLayer;
using SH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentHub.Controllers
{
    public class BaseController : Controller
    {
        ISHRepo _repo;
        ISHBusiness _biz;

        public BaseController(ISHRepo IRepo, ISHBusiness Biz)
        {
            _repo = IRepo;
            _biz = Biz;
        }

        protected ISHRepo IRepo
        {
            get
            {
                return _repo;
            }
        }

        protected ISHBusiness Biz
        {
            get
            {
                return _biz;
            }
        }


    }
}