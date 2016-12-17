using Step.Application;
using Step.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Step.Helper
{
    public class OperateContext
    {
        static ApplicationSession _AppSession;
        public static ApplicationSession AppSession
        {
            get
            {
                return new ApplicationSession();
            }
            set
            {
                _AppSession = value;
            }
        }


        #region Helper Ajax
        public static ActionResult RedirectAjax(string status, string msg, object data, string backurl)
        {
            AjaxMsg ajax = new AjaxMsg()
            {
                Status = status,
                Msg = msg,
                Data = data,
                BackUrl = backurl
            };
            JsonResult res = new JsonResult();
            res.Data = ajax;
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }
        #endregion


    }
}
