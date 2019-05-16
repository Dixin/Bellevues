// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerExtensions.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the ControllerExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Common
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class ControllerExtensions
    {
        #region Public Methods and Operators

        public static RedirectToRouteResult RedirectToVersion(this Controller controller, string actionName, string controllerName)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            ViewVersion viewVersion = controller.HttpContext.Request.IsMobile() ? ViewVersion.Mobile : ViewVersion.Full;
            RouteValueDictionary routeValues = viewVersion == ViewVersion.Mobile ? new RouteValueDictionary(new { version = ViewVersion.Mobile }) : null;
            RouteValueDictionary routeValues1 = controller.RouteData == null
                                                    ? MergeRouteValues(actionName, controllerName, null, routeValues, true)
                                                    : MergeRouteValues(actionName, controllerName, controller.RouteData.Values, routeValues, true);
            return new RedirectToRouteResult(routeValues1);
        }

        public static ViewResult View(this ControllerBase controller, ViewVersion? viewType, string viewName)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            if (string.IsNullOrWhiteSpace(viewName))
            {
                throw new ArgumentNullException("viewName");
            }

            if (viewType == ViewVersion.Mobile)
            {
                viewName = "{0}.Mobile".FormatInvariant(viewName);
            }

            return new ViewResult() { ViewName = viewName, ViewData = controller.ViewData, TempData = controller.TempData };
        }

        #endregion

        #region Methods

        private static IEnumerable<KeyValuePair<string, object>> GetRouteValues(RouteValueDictionary routeValues)
        {
            return routeValues == null ? new RouteValueDictionary() : new RouteValueDictionary(routeValues);
        }

        private static RouteValueDictionary MergeRouteValues(
            string actionName, string controllerName, RouteValueDictionary implicitRouteValues, RouteValueDictionary routeValues, bool includeImplicitMvcValues)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
            if (includeImplicitMvcValues)
            {
                object obj;
                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("action", out obj))
                {
                    routeValueDictionary["action"] = obj;
                }

                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("controller", out obj))
                {
                    routeValueDictionary["controller"] = obj;
                }
            }

            if (routeValues != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in GetRouteValues(routeValues))
                {
                    routeValueDictionary[keyValuePair.Key] = keyValuePair.Value;
                }
            }

            if (actionName != null)
            {
                routeValueDictionary["action"] = (object)actionName;
            }

            if (controllerName != null)
            {
                routeValueDictionary["controller"] = (object)controllerName;
            }

            return routeValueDictionary;
        }

        #endregion
    }
}