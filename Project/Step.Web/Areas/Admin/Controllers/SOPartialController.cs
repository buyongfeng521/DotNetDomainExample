using Step.Code;
using Step.Domain.Entity;
using Step.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step.Web.Areas.Admin.Controllers
{
    public class SOPartialController : Controller
    {
        public ActionResult Menu()
        {

            //List<t_menuEntity> listMenu = OperateContext.AppSession.t_menuApp.GetList(m=>m.parent_id == "0",m=>m.menu_order);
            //Session[OperateMsgModel.MainMenuList] = listMenu;
            //List<t_menuEntity> listSubMenu = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id != "0", m => m.menu_order);
            //Session[OperateMsgModel.SubMenuList] = listSubMenu;


            //ViewBag.ListMenu = Session[OperateMsgModel.MainMenuList];
            //ViewBag.ListSubMenu = Session[OperateMsgModel.SubMenuList];


            t_admin_userEntity user = OperateHelper.LoginUser();
            if (user != null)
            {
                if (Session[OperateMsgModel.MainMenuList] == null)
                {
                    if (OperateHelper.IsAdmin())
                    {
                        List<t_menuEntity> listMenu = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id == "0", m => m.menu_order);
                        Session[OperateMsgModel.MainMenuList] = listMenu;
                    }
                    else
                    {
                        List<string> listSubMenuID = OperateContext.AppSession.t_role_menuApp.GetList(r=>r.role_id == user.role_id).Select(m => m.menu_id).ToList();
                        List<string> listParentID = OperateContext.AppSession.t_menuApp.GetList(m => listSubMenuID.Contains(m.menu_id)).Select(m => m.parent_id).Distinct().ToList();
                        List<t_menuEntity> listMenu = OperateContext.AppSession.t_menuApp.GetList(m => (listParentID.Contains(m.menu_id)) || m.menu_name == "控制台", m => m.menu_order);
                        Session[OperateMsgModel.MainMenuList] = listMenu;
                    }
                }
                if (Session[OperateMsgModel.SubMenuList] == null)
                {
                    //防止菜单Session为空
                    OperateHelper.MenuSessionNullWrite();
                }
            }
            else
            {
                return null;
            }


            ViewBag.ListMenu = Session[OperateMsgModel.MainMenuList];
            ViewBag.ListSubMenu = Session[OperateMsgModel.SubMenuList];




            return PartialView();
        }
    }
}