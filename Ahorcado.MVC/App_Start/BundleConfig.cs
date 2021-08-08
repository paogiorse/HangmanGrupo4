using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Ahorcado.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/JQueryKnockOut").Include(
                "~/Scripts/jquery-{version}.js",
                 "~/Scripts/knockout-{version}.js",
                 "~/Scripts/knockout.mapping-latest.js",
                 "~/Scripts/pnotify.custom.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                 "~/Content/Site.css",
                 "~/Content/bootstrap.css",
                 "~/Content/pnotify.custom.css"
                ));
        }
    }
}