﻿using System.Web;
using System.Web.Optimization;

namespace Apps.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //easyui js 文件
            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                      "~/Scripts/jquery.easyui-1.4.5.js",
                      "~/Scripts/locale/easyui-lang-zh_CN.js"));

            //jquery.form js 文件
            bundles.Add(new ScriptBundle("~/bundles/form").Include(
                      "~/Scripts/jquery.form.js"));

            //home js 文件
            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                      "~/Scripts/home.js"));

            //tree js 文件
            bundles.Add(new ScriptBundle("~/bundles/jquerytree").Include(
                      "~/Scripts/jquery.tree.js"));

            bundles.Add(new ScriptBundle("~/bundles/easyui.plus").Include(
                       "~/Scripts/jquery.easyui.plus.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //easyui css 文件
            bundles.Add(new StyleBundle("~/Content/easyuicss").Include(
                       "~/Content/themes/default/easyui.css",
                       "~/Content/themes/icon.css"));

            bundles.Add(new StyleBundle("~/Content/tree").Include(
                   "~/Content/tree.css"));
        }
    }
}
