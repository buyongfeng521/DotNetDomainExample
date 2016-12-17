using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step.Helper
{
    public class ContentHelper
    {
        #region Admin
        public static string GetRoleNameByID(string role_id)
        {
            string result = "";
            var model = OperateContext.AppSession.t_roleApp.GetEntity(r=>r.role_id == role_id);
            if (model != null)
            {
                result = model.role_name;
            }
            return result;
        } 
        #endregion
    }
}
