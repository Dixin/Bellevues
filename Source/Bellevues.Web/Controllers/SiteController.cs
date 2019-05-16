// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteController.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the SiteController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.Controllers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.IO;
    using System.Web.Mvc;
    using System.Web.UI;

    using Bellevues.Common;
    using Bellevues.Web.Models;
    using Bellevues.Web.Views;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SiteController : Controller
    {
        #region Public Methods and Operators

        public ActionResult Full(SiteViewId id)
        {
            Uri uri = this.Request.Url;
            if (uri.Host.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
            {
                int index = uri.AbsoluteUri.IndexOf("www.");
                string url = uri.AbsoluteUri.Remove(index, "www.".Length);
                return this.Redirect(url);
            }

            string requestPath = this.Request.Path.Trim(Path.AltDirectorySeparatorChar);
            string applicationPath = (this.Request.ApplicationPath ?? Path.AltDirectorySeparatorChar.ToString(CultureInfo.InvariantCulture)).Trim(Path.AltDirectorySeparatorChar);
            if (id == SiteViewId.Home
                && string.Equals(requestPath, applicationPath, StringComparison.OrdinalIgnoreCase)
                && this.Request.IsMobile())
            {
                // return this.RedirectToAction("Mobile", new { id = id.ToString() });
            }

            return this.View("Full.{0}".FormatInvariant(id.ToString()));
        }

        public ActionResult Mobile(SiteViewId id)
        {
            return this.View("Mobile.{0}".FormatInvariant(id.ToString()));
        }

        #endregion
    }
}
