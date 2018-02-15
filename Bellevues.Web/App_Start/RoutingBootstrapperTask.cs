// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoutingBootstrapperTask.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the RoutingBootstrapperTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    using System;
    using System.ComponentModel.Composition;
    using System.Web.Mvc;
    using System.Web.Routing;

    [Export(typeof(IBootstrapperTask))]
    internal class RoutingBootstrapperTask : IBootstrapperTask
    {
        #region Public Methods and Operators

        public void Run(Bootstrapper bootstrapper)
        {
            if (bootstrapper == null)
            {
                throw new ArgumentNullException("bootstrapper");
            }

            RegisterRoutes(bootstrapper.RouteCollection);
        }

        #endregion

        #region Methods

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ActionId",
                "{action}/{id}", // /full/home
                new
                    {
                        controller = "Site",
                        action = "Full",
                        id = "Home"
                    },
                new
                    {
                        action = "full|mobile",
                        id = @"^[0-9a-zA-Z\-]+$"
                    });

            routes.MapRoute(
                "Id",
                "{id}", // /home
                new
                    {
                        controller = "Site",
                        action = "Full",
                        id = "Home"
                    },
                new
                    {
                        id = @"^[0-9a-zA-Z\-]+$"
                    });
        }

        #endregion
    }
}
