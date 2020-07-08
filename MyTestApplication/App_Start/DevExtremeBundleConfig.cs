using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MyTestApplication.App_Start
{
    public class DevExtremeBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var scriptBundle = new ScriptBundle("~/Scripts/DevExtremeBundle");
            var styleBundle = new StyleBundle("~/Content/DevExtremeBundle");

            // CLDR scripts
            scriptBundle
                .Include("~/DevExpress/js/cldr.js")
                .Include("~/DevExpress/js/cldr/event.js")
                .Include("~/DevExpress/js/cldr/supplemental.js")
                .Include("~/DevExpress/js/cldr/unresolved.js");

            // Globalize 1.x
            scriptBundle
                .Include("~/DevExpress/js/globalize.js")
                .Include("~/DevExpress/js/globalize/message.js")
                .Include("~/DevExpress/js/globalize/number.js")
                .Include("~/DevExpress/js/globalize/currency.js")
                .Include("~/DevExpress/js/globalize/date.js");

            // NOTE: jQuery may already be included in the default script bundle. Check the BundleConfig.cs file​​​
            //scriptBundle
            //    .Include("~/Scripts/jquery-3.1.0.js");

            // JSZip for client side export
            //scriptBundle
            //    .Include("~/Scripts/jszip.js");

            // DevExtreme + extensions
            scriptBundle
                .Include("~/DevExpress/js/dx.all.js")
                .Include("~/DevExpress/js/aspnet/dx.aspnet.data.js")
                .Include("~/DevExpress/js/aspnet/dx.aspnet.mvc.js");

            // dxVectorMap data (http://js.devexpress.com/Documentation/Guide/Data_Visualization/VectorMap/Providing_Data/#Data_for_Areas)
            //scriptBundle
            //    .Include("~/Scripts/vectormap-data/africa.js")
            //    .Include("~/Scripts/vectormap-data/canada.js")
            //    .Include("~/Scripts/vectormap-data/eurasia.js")
            //    .Include("~/Scripts/vectormap-data/europe.js")
            //    .Include("~/Scripts/vectormap-data/usa.js")
            //    .Include("~/Scripts/vectormap-data/world.js");


            // DevExtreme
            // NOTE: see the available theme list here: http://js.devexpress.com/Documentation/Guide/Themes/Predefined_Themes/                    
            styleBundle
                .Include("~/DevExpress/css/dx.common.css")
                .Include("~/DevExpress/css/dx.light.css");

            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);

#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}