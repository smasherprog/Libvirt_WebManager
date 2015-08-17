using System.Web;
using System.Web.Optimization;

namespace Libvirt_WebManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery-ui-{version}.js",
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/jquery.validate.min.js",
                            "~/Scripts/jquery.unobtrusive-ajax.min.js",
                            "~/Scripts/jquery.validate.unobtrusive.js",
                           "~/Scripts/jQueryFileTree.js",
                           "~/Scripts/AjaxHelpers.js",
                            "~/Scripts/Libvirt.js",
                             "~/Scripts/knockout-{version}.js",
                             "~/Scripts/Host.js",
                             "~/Scripts/jquery.signalR-{version}.js",
                                 "~/Scripts/jquery.jgrowl.min.js",
                                 "~/Scripts/Libvirt.js",
                                    "~/Scripts/context.js",
                                    "~/Scripts/Chart.min.js",
                                    "~/Scripts/jquery.mask.js",
                    "~/Scripts/Common.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/themes/base/jquery.ui.core.css",
                  "~/Content/themes/base/jquery.ui.resizable.css",
                  "~/Content/themes/base/jquery.ui.selectable.css",
                  "~/Content/themes/base/jquery.ui.accordion.css",
                  "~/Content/themes/base/jquery.ui.autocomplete.css",
                  "~/Content/themes/base/jquery.ui.button.css",
                  "~/Content/themes/base/jquery.ui.dialog.css",
                  "~/Content/themes/base/jquery.ui.slider.css",
                  "~/Content/themes/base/jquery.ui.tabs.css",
                  "~/Content/themes/base/jquery.ui.datepicker.css",
                  "~/Content/themes/base/jquery.ui.progressbar.css",
                  "~/Content/themes/base/jquery.ui.theme.css",
                      "~/Content/site.css",
                      "~/Content/jQueryFileTree.css",
                      "~/Content/jquery.jgrowl.min.css",
                      "~/Content/contextjs.bootstrap.css",
                      "~/css/font-awesome.min.css"


              

                      ));
        }
    }
}
