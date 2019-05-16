// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebViewPageExtensions.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the WebViewPageExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    public static class WebViewPageExtensions
    {
        #region Public Methods and Operators

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "page", Justification = Justifications.ByDesign)]
        public static bool IsDebug(this WebViewPage page)
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        #endregion
    }
}