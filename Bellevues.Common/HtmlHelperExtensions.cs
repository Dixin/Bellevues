// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelperExtensions.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the HtmlHelperExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Common
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        #region Public Methods and Operators

        public static IHtmlString Script(this HtmlHelper htmlHelper, string path)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException("htmlHelper");
            }

            TagBuilder tagBuilder = new TagBuilder("script");
            tagBuilder.MergeAttribute("type", "text/javascript");
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            tagBuilder.MergeAttribute("src", urlHelper.Content(path));
            return htmlHelper.Raw(tagBuilder.ToString(TagRenderMode.Normal));
        }

        #endregion
    }
}
