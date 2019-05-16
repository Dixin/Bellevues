// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundlingBootstrapperTask.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the BundlingBootstrapperTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    using System;
    using System.Web.Optimization;

    public class BundlingBootstrapperTask : IBootstrapperTask
    {
        #region Public Methods and Operators

        public void Run(Bootstrapper bootstrapper)
        {
            if (bootstrapper == null)
            {
                throw new ArgumentNullException("bootstrapper");
            }

            RegisterBundles(bootstrapper.BundleCollection);
        }

        #endregion

        #region Methods

        private static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*", "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(
                new StyleBundle("~/Content/themes/base/css").Include(
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
                    "~/Content/themes/base/jquery.ui.theme.css"));
        }

        #endregion
    }
}
