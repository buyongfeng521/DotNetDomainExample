using Step.Code;
using Step.Domain.Entity;
using Step.Helper;
using Step.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Step.Web.Areas.Admin.Controllers
{
    [LoginCheck]
    public class SettingsController : Controller
    {

        #region Admin
        [HttpGet]
        public ActionResult AdminUserList(string keywords = "")
        {
            List<t_admin_userEntity> list = OperateContext.AppSession.t_admin_userApp.GetListByDesc(u=>u.user_name != OperateMsgModel.AdminUserName && (u.user_name.Contains(keywords) || u.user_realname.Contains(keywords)),u=>u.create_time);

            ViewBag.UserRole = SelectHelper.GetRoleSelList();

            return View(list);
        }
        [HttpPost]
        public ActionResult AdminUserAdd(string user_name, string user_psw, string user_role)
        {
            AjaxMsg ajax = new AjaxMsg();
            //1.0 check
            if (string.IsNullOrWhiteSpace(user_name))
            {
                ajax.Msg = "用户名不能为空";
                return Json(ajax);
            }
            if (string.IsNullOrWhiteSpace(user_psw))
            {
                ajax.Msg = "密码不能为空";
                return Json(ajax);
            }
            if (OperateContext.AppSession.t_admin_userApp.GetEntity(u => u.user_name == user_name) != null)
            {
                ajax.Msg = "此用户已存在";
                return Json(ajax);
            }
            //2.0 do
            string strSalt = Md5.md5(Common.CreateNo(), 16).ToLower();
            t_admin_userEntity addModel = new t_admin_userEntity() { 
                user_id = Common.GuId(),
                role_id = user_role,
                user_name = user_name.Trim(),
                user_salt = strSalt,
                user_psw = Md5.PswProcess(user_psw.Trim(),strSalt),//Md5.md5(user_psw.Trim() + "2016" + strSalt, 32),
                user_realname = "",
                last_login_time = DateTime.Now,
                create_time = DateTime.Now
            };
            OperateContext.AppSession.t_admin_userApp.Insert(addModel);
            ajax.Status = "ok";
            ajax.Msg = OperateMsgModel.AddSuc;
            return Json(ajax);
        }

        [HttpPost]
        public ActionResult AdminUserEdit(string user_name, string user_psw, string uRole, string user_id)
        {
            AjaxMsg ajax = new AjaxMsg();
            //1.0 check
            if (string.IsNullOrWhiteSpace(user_name))
            {
                ajax.Msg = "用户名不能为空";
                return Json(ajax);
            }
            if (string.IsNullOrWhiteSpace(user_psw))
            {
                ajax.Msg = "密码不能为空";
                return Json(ajax);
            }
            if (OperateContext.AppSession.t_admin_userApp.GetEntity(u => u.user_name == user_name && u.user_id != user_id) != null)
            {
                ajax.Msg = "此用户已存在";
                return Json(ajax);
            }
            //2.0 do
            t_admin_userEntity editModel = OperateContext.AppSession.t_admin_userApp.GetEntity(user_id);
            if (editModel != null)
            {
                string strSalt = Md5.md5(Common.CreateNo(), 16).ToLower();
                editModel.role_id = uRole;
                editModel.user_name = user_name.Trim();
                if (user_psw != "**********************")
                {
                    editModel.user_salt = strSalt;
                    editModel.user_psw = Md5.PswProcess(user_psw.Trim(),strSalt);//Md5.md5(user_psw.Trim() + "2016" + strSalt, 32);
                }
                OperateContext.AppSession.t_admin_userApp.Update(editModel);
                ajax.Status = "ok";
                ajax.Msg = OperateMsgModel.EditSuc;
            }
            else
            {
                ajax.Msg = OperateMsgModel.VoidModel;
            }
            
            return Json(ajax);
        }

        [HttpGet]
        public ActionResult AdminUserGet(string user_id)
        {
            var model = OperateContext.AppSession.t_admin_userApp.GetEntity(user_id);
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


        [HttpGet]
        public ActionResult ModifyPSW()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ModifyPSW(string oldPassword,string password, string secondPassword)
        {
            AjaxMsg ajax = new AjaxMsg();
            //1.0 check
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(password.Trim()) || string.IsNullOrEmpty(secondPassword.Trim()))
            {
                ajax.Msg = "请填入密码";
                return View();
            }
            if (password.Trim() != secondPassword.Trim())
            {
                ajax.Msg = "两次密码不相同";
                return Json(ajax);
            }
            t_admin_userEntity user = OperateHelper.LoginUser();
            if (user.user_psw != Md5.PswProcess(oldPassword, user.user_salt))
            {
                ajax.Msg = "密码错误";
                return Json(ajax);
            }

            //2.0 do
            if (user != null)
            {
                user.user_psw = Md5.PswProcess(password, user.user_salt);
                OperateContext.AppSession.t_admin_userApp.Update(user);
                ajax.Status = "ok";
                ajax.Msg = OperateMsgModel.EditSuc;
                
            }

            return Json(ajax);
        }

        #endregion



        #region Role
        [HttpGet]
        public ActionResult RoleList(string keywords = "")
        {
            //1.0 where
            Expression<Func<t_roleEntity, bool>> where = r => r.role_name.Contains(keywords);
            //2.0 result
            List<t_roleEntity> listRole = OperateContext.AppSession.t_roleApp.GetList(where, r => r.create_time);
            ViewBag.Keywords = keywords;

            ViewBag.ListMenu = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id == "0", m => m.menu_order); ;
            ViewBag.ListSubMenu = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id != "0", m => m.menu_order);

            return View(listRole);
        }

        [HttpPost]
        public ActionResult RoleSave(t_roleEntity entity)
        {
            AjaxMsg ajax = new AjaxMsg();
            //1.0 check
            if (string.IsNullOrEmpty(entity.role_name))
            {
                ajax.Msg = OperateMsgModel.VoidName;
                return Json(ajax);
            }
            //2.0 do
            //a Add
            if (string.IsNullOrEmpty(entity.role_id))
            {
                entity.role_id = Common.GuId();
                entity.create_time = DateTime.Now;
                OperateContext.AppSession.t_roleApp.Insert(entity);
                ajax.Status = "ok";
                ajax.Msg = OperateMsgModel.AddSuc;
            }
            //b Edit
            else
            {
                OperateContext.AppSession.t_roleApp.Update(entity);
                ajax.Status = "ok";
                ajax.Msg = OperateMsgModel.AddSuc;
            }
            return Json(ajax);
        }
        
        [HttpPost]
        public ActionResult AssignPermissions(string ids, string role_id)
        {
            AjaxMsg ajax = new AjaxMsg() { Status = "ok", Msg = "分配成功" };

            if (!string.IsNullOrEmpty(role_id))
            {
                //a 删除
                if (OperateContext.AppSession.t_role_menuApp.GetEntity(r => r.role_id == role_id) != null)
                {
                    OperateContext.AppSession.t_role_menuApp.Delete(r => r.role_id == role_id);
                }
                if (!string.IsNullOrEmpty(ids))
                {
                    //b 新增
                    var listIDS = ids.Split(',');
                    for (int i = 0; i < listIDS.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(listIDS[i]))
                        {
                            t_role_menuEntity roleMenu = new t_role_menuEntity()
                            {
                                role_id = role_id,
                                menu_id = listIDS[i]
                            };
                            OperateContext.AppSession.t_role_menuApp.Insert(roleMenu);
                        }
                    }
                }
            }

            return Json(ajax);
        }
        [HttpGet]
        public ActionResult RoleModelGet(string id)
        {
            t_roleEntity model = OperateContext.AppSession.t_roleApp.GetEntity(id);
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        [HttpGet]
        public ActionResult RoleMenusGet(string role_id)
        {

            if (!string.IsNullOrEmpty(role_id))
            {
                List<t_role_menuEntity> list = OperateContext.AppSession.t_role_menuApp.GetList(r => r.role_id == role_id, r => r.role_id);
                if (list.Count() > 0)
                {
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }
        #endregion



        #region Menu
        [HttpGet]
        public ActionResult MenuList(string keywords = "")
        {
            ViewBag.Keywords = keywords;
            ViewBag.Menus = OperateContext.AppSession.t_menuApp.GetList(t=>t.parent_id == "0",t=>t.menu_order);
            ViewBag.SubMenus = OperateContext.AppSession.t_menuApp.GetList(t => t.parent_id != "0",t=>t.menu_order);
            ViewBag.SelParentMenu = SelectHelper.GetParentMenuList();
            return View();
        }
        [HttpPost]
        public ActionResult MenuAdd(t_menuEntity model,string menu_style)
        {
            AjaxMsg ajax = new AjaxMsg();
            model.menu_style = menu_style;
            //1.0 check
            if (string.IsNullOrWhiteSpace(model.menu_name))
            {
                ajax.Msg = "菜单名称不能为空";
                return Json(ajax);
            }
            if(string.IsNullOrWhiteSpace(model.menu_value))
            {
                ajax.Msg = "菜单值不能为空";
                return Json(ajax);
            }
            //2.0 do
            //a add
            if (string.IsNullOrEmpty(model.menu_id))
            {
                if (OperateContext.AppSession.t_menuApp.GetEntity(m=>m.menu_name == model.menu_name || m.menu_value == model.menu_value) != null)
                {
                    ajax.Msg = "菜单值已存在";
                    return Json(ajax);
                }
                model.menu_id = Common.GuId();
                model.create_time = DateTime.Now;
                OperateContext.AppSession.t_menuApp.Insert(model);
                ajax.Msg = OperateMsgModel.AddSuc;
                ajax.Status = "ok";
            }
            //b edit
            else
            {
                if (OperateContext.AppSession.t_menuApp.GetEntity(m => (m.menu_name == model.menu_name || m.menu_value == model.menu_value) && m.menu_id != model.menu_id) != null)
                {
                    ajax.Msg = "菜单值已存在";
                    return Json(ajax);
                }
                OperateContext.AppSession.t_menuApp.Update(model);
                ajax.Msg = OperateMsgModel.AddSuc;
                ajax.Status = "ok";
            }

            return Json(ajax);
        }
        [HttpPost]
        public ActionResult MenuDelete(string id = "")
        {
            AjaxMsg ajax = new AjaxMsg();

            t_menuEntity model = OperateContext.AppSession.t_menuApp.GetEntity(m => m.menu_id == id);
            if (model != null)
            {
                if (model.parent_id == "0")
                {
                    if (OperateContext.AppSession.t_menuApp.GetEntity(m => m.parent_id == model.menu_id) != null)
                    {
                        ajax.Msg = "有所属的子菜单，如果想删除，请删除子菜单后，再执行删除";
                    }
                    else
                    {
                        //TO DO
                        OperateContext.AppSession.t_role_menuApp.Delete(m => m.menu_id == id);
                        OperateContext.AppSession.t_menuApp.Delete(m => m.menu_id == id);
                        ajax.Msg = OperateMsgModel.DelSuc;
                        ajax.Status = "ok";
                    }
                }
                else
                {
                    //TO DO
                    OperateContext.AppSession.t_role_menuApp.Delete(m => m.menu_id == id);
                    OperateContext.AppSession.t_menuApp.Delete(m => m.menu_id == id);
                    ajax.Msg = OperateMsgModel.DelSuc;
                    ajax.Status = "ok";
                }
            }
            else
            {
                ajax.Msg = OperateMsgModel.VoidModel;
            }

            return Json(ajax);
        }

        [HttpGet]
        public ActionResult MenuModelGet(string id)
        {
            t_menuEntity result = OperateContext.AppSession.t_menuApp.GetEntity(id);
            if (result != null)
            {
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        #endregion



    }
}