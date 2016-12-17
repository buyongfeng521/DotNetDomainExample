using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Step.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //boot
            bundles.Add(new ScriptBundle("~/Content/JS/Boot").Include(
                "~/Content/js/jquery-2.1.4.js",
                "~/Content/boot/js/bootstrap.js",
                "~/Content/bootstrap-fileinput/js/fileinput.js",
                "~/Content/bootstrap-fileinput/js/fileinput_locale_zh.js",
                "~/Content/bootstrapvalidator/bootstrapValidator.js",
                "~/Content/bootstrapvalidator/language/zh_CN.js",
                "~/Scripts/messenger/messenger.js",
                "~/Scripts/messenger/messenger-theme-future.js"));
            //ace 
            bundles.Add(new ScriptBundle("~/Content/JS/Ace").Include(
                "~/Content/ACE/js/ace-extra.js",
                "~/Content/ACE/js/ace-elements.js",
                "~/Content/ACE/js/ace.js",
                "~/Content/ACE/js/bootstrap-tag.js",
                "~/Content/ACE/js/typeahead-bs2.min.js",
                "~/Content/ACE/js/jquery.nestable.js"));
            //other
            bundles.Add(new ScriptBundle("~/Content/JS/Other").Include(
                "~/Content/My97DatePicker/WdatePicker.js",
                "~/Content/UEditor/ueditor.config.js",
                "~/Content/UEditor/ueditor.all.js",
                "~/Content/UEditor/lang/zh-cn.js",
                "~/Scripts/jquery.MsgProcess.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/StepCommon.js"));


            //css
            //boot
            bundles.Add(new StyleBundle("~/Content/CSS/Boot").Include(
                        "~/Content/boot/css/bootstrap.css",
                        "~/Content/bootstrap-fileinput/css/default.css",
                        "~/Content/bootstrap-fileinput/css/fileinput.css",
                        "~/Content/bootstrapvalidator/bootstrapValidator.css",
                        "~/Content/messenger/messenger.css",
                        "~/Content/messenger/messenger-theme-future.css"));
            //ace
            bundles.Add(new StyleBundle("~/Content/CSS/Ace").Include(
                "~/Content/ACE/css/font-awesome.css",
                "~/Content/ACE/css/ace.css",
                "~/Content/ACE/css/ace-rtl.css",
                "~/Content/ACE/css/ace-skins.css"));
            //other




        }
    }
}