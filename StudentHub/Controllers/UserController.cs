using SH.BusinessLayer;
using SH.Entities;
using SH.Repository;
using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentHub.Controllers
{
    public class UserController : BaseController
    {

        private readonly ISHBusiness _ISBiz;
        private readonly ISHRepo _ISrepo;
        public UserController(ISHRepo repo, ISHBusiness biz) : base(repo, biz)
        {
            _ISrepo = repo;
            _ISBiz = biz;
        }

        public ActionResult RegisterUser()                                              //Form to add new user
        {
            RegisterUserVM registerUserVM = new RegisterUserVM();
            List<SelectListItem> Type = new List<SelectListItem>()
            {
              new SelectListItem {Text="Select",Value="",Selected=true },
              new SelectListItem {Text="Professor",Value="Professor" },
              new SelectListItem {Text="Student",Value="Student"},
              new SelectListItem {Text="Admin",Value="Admin"},
            };
            TempData["Type"] = Type;
            return View(registerUserVM);
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterUserVM registerUserVM)                 //Save new user data
        {
            var SaveUserData = Biz.SaveUser(registerUserVM);
            return RedirectToAction("UserLogin");
        }
        public ActionResult UserLogin()                                                 //Login form
        {
            RegisterUserVM registerUserVM = new RegisterUserVM();
            return View(registerUserVM);
        }
        [HttpPost]
        public ActionResult UserLogin(string Email, string Password)                             //Authorisation
        {
            var LoginUser = Biz.UserLogin(Email, Password);
            if(LoginUser!= null)
            {
                Session["Type"] = LoginUser.Type;
                Session["Name"] = LoginUser.Name;
            }
            else
            {
                RegisterUserVM registerUserVM = new RegisterUserVM();
                return View(registerUserVM);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()                                                    //Log out user
        {
            Session.Clear();
            return RedirectToAction("UserLogin");
        }
    }
}