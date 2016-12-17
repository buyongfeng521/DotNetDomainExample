using Step.Application;
using Step.Code;
using Step.Domain.Entity;
using Step.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [LoginCheck]
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UName, string UPassword, string cbRemberMe)
        {
            AjaxMsg ajax = new AjaxMsg();
            //1.0 check
            if (string.IsNullOrWhiteSpace(UName))
            {
                ajax.Msg = "请输入用户名";
                return Json(ajax);
            }
            if (string.IsNullOrWhiteSpace(UPassword))
            {
                ajax.Msg = "请输入密码";
                return Json(ajax);
            }
            //2.0 valid check
            t_admin_userEntity user = null;
            if (new t_admin_userApp().ValidUserPsw(UName, UPassword, ref user))
            {
                ajax.Msg = "登录成功";
                ajax.Status = "ok";
                Session[OperateMsgModel.SessionLoginUser] = user;
                if (cbRemberMe == "on")
                {
                    //cookie
                    HttpCookie cookie = new HttpCookie(OperateMsgModel.CookieLoginUser, user.user_id);
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie);
                }
                return Json(ajax);
            }
            else
            {
                ajax.Msg = "用户名或密码错误";
            }

            return Json(ajax);
        }

        public ActionResult Logout()
        {
            Session[OperateMsgModel.SessionLoginUser] = null;
            Session.Clear();

            if (Request.Cookies[OperateMsgModel.CookieLoginUser] != null)
            {
                HttpCookie ck = Request.Cookies[OperateMsgModel.CookieLoginUser];
                ck.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(ck);
            }
            return RedirectToAction("Login");
        }

        [LoginCheck]
        [HttpGet]
        public ActionResult NoPermission()
        {
            return View();
        }


    }
}