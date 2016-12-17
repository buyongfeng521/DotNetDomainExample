using Step.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Step.Helper
{
    public class SelectHelper
    {
        #region 菜单
        public static SelectList GetRoleSelList()
        {
            List<t_roleEntity> listRole = OperateContext.AppSession.t_roleApp.GetList(r => string.IsNullOrEmpty(r.role_id) == false, m => m.create_time);
            SelectList result = new SelectList(listRole, "role_id", "role_name");
            return result;
        }

        public static SelectList GetParentMenuList()
        {
            List<t_menuEntity> listParentMenu = OperateContext.AppSession.t_menuApp.GetList(m => m.parent_id == "0", m => m.menu_order);
            listParentMenu.Insert(0, new t_menuEntity() { menu_id = "0", menu_name = "父级菜单" });

            SelectList result = new SelectList(listParentMenu, "menu_id", "menu_name");

            return result;
        }
        #endregion
    }
}
