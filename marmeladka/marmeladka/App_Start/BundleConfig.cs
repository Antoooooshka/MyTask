using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace marmeladka.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/content/js/js/jquery.js",
                "~/content/js/js/jquery.scrollUp.min.js", "~/content/js/js/jquery.prettyPhoto.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/content/js/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/otherjs").Include("~/content/js/js/bootstrap.min.js",
                "~/content/js/js/price-range.js", "~/content/js/js/main.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include("~/content/css/bootstrap.min.css",
                "~/content/css/prettyPhoto.css", "~/content/css/price-range.css", "~/content/css/animate.css",
                "~/content/css/main.css", "~/content/css/responsive.css", "~/content/css/font-awesome.min.css"));
        }
    }
}