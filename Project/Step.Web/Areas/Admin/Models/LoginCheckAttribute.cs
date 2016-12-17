using Step.Code;
using Step.Domain.Entity;
using Step.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.Web.Areas.Admin.Models
{
    public class LoginCheckAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //a 校验用户是否登录
            if (!OperateHelper.IsLogin())
            {
                bool flag = filterContext.HttpContext.Request.IsAjaxRequest();

                //if (filterContext.ActionDescriptor.IsDefined(typeof(AjaxRequestAttribute), false)
                //    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AjaxRequestAttribute), false))
                //{
                //    filterContext.Result = OperateContext.RedirectAjax("nologin", "登陆失效", null, "/Home/Login");
                //}
                if (flag)
                {
                    filterContext.Result = OperateContext.RedirectAjax("nologin", "登录失效", null, "/Admin/Home/Login");
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Admin/Home/Login");
                }
                return;
            }

            //b 权限判断
            t_admin_userEntity user = OperateHelper.LoginUser();
            if (user != null && user.user_name != OperateMsgModel.AdminUserName)
            {
                string strAreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
                string strControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                string strActionName = filterContext.ActionDescriptor.ActionName.ToLower();

                if (!OperateHelper.HasPermission(strAreaName,strControllerName, strActionName, user.user_id))
                {
                    filterContext.Result = new RedirectResult("/Admin/Home/NoPermission");
                }
            }


        }
    }
}