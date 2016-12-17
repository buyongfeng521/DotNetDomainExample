using Step.Code;
using Step.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Step.Helper
{
    public class OperateHelper
    {
        #region Http上下文相关属性
        static HttpContext ContextHttp
        {
            get
            {
                return HttpContext.Current;
            }
        }

        static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }

        static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }

        static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
        #endregion


        /// <summary>
        /// 当前用户是否登陆
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            bool result = false;
            //1.(Session && Cookie)
            if (Session[OperateMsgModel.SessionLoginUser] == null)
            {
                if (Request.Cookies[OperateMsgModel.CookieLoginUser] != null)
                {
                    string ckUserID = Request.Cookies[OperateMsgModel.CookieLoginUser].Value;
                    if (!string.IsNullOrEmpty(ckUserID) )
                    {
                        t_admin_userEntity user = OperateContext.AppSession.t_admin_userApp.GetEntity(u => u.user_id == ckUserID);
                        if (user != null)
                        {
                            Session[OperateMsgModel.SessionLoginUser] = user;
                            result = true;
                        }
                    }
                }
            }
            else
            {
                result = true;
            }

            //2.0 result
            return result;
        }


        /// <summary>
        /// 登录用户名
        /// </summary>
        /// <returns></returns>
        public static t_admin_userEntity LoginUser()
        {
            t_admin_userEntity user = Session[OperateMsgModel.SessionLoginUser] as t_admin_userEntity;
            return user;
        }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        /// <returns></returns>
        public static bool IsAdmin()
        {
            bool result = false;
            t_admin_userEntity user = Session[OperateMsgModel.SessionLoginUser] as t_admin_userEntity;
            if (user != null)
            {
                if (user.user_name == OperateMsgModel.AdminUserName)
                {
                    result = true;
                }
            }

            return result;
        }

        


        public static void MenuSessionNullWrite()
        {
            //防止session为空
            if (Session[OperateMsgModel.SubMenuList] == null)
            {
                if (OperateHelper.IsAdmin())
                {
                    List<t_menuEntity> listSubMenu = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id != "0", m => m.menu_order);
                    Session[OperateMsgModel.SubMenuList] = listSubMenu;
                }
                else
                {
                    t_admin_userEntity user = OperateHelper.LoginUser();
                    List<string> listParentID = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id == "0").Select(m => m.menu_id).ToList();
                    List<string> listSubID = OperateContext.AppSession.t_role_menuApp.GetList(m => m.role_id == user.role_id && listParentID.Contains(m.menu_id) == false).Select(m => m.menu_id).ToList();
                    List<t_menuEntity> listSubMenu = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id != "0" && listSubID.Contains(m.menu_id), m => m.menu_order);
                    Session[OperateMsgModel.SubMenuList] = listSubMenu;
                }
            }
        }

        /// <summary>
        /// 是否有权限
        /// </summary>
        /// <param name="strControllerName"></param>
        /// <param name="strActionName"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static bool HasPermission(string strArea,string strControllerName, string strActionName, string user_id)
        {
            bool result = true;

            try
            {
                if (OperateContext.AppSession.t_menuApp.GetEntity(m => m.menu_controller.ToLower() == strControllerName && m.menu_action.ToLower() == strActionName) != null)
                {
                    //if(Session)
                    if (strArea.ToLower() == "admin" && strControllerName.ToLower() == "home" && strActionName.ToLower() == "index")
                    {
                        result = true;
                    }
                    else
                    {
                        //防止菜单Session为空
                        MenuSessionNullWrite();

                        t_menuEntity menu = (Session[OperateMsgModel.SubMenuList] as List<t_menuEntity>).Where(m => m.menu_area.ToLower() == strArea && m.menu_controller.ToLower() == strControllerName && m.menu_action.ToLower() == strActionName).FirstOrDefault();
                        if (menu != null)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }




    }
}
