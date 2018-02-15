// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiBootstrapperTask.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the WebApiBootstrapperTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;

    using Bellevues.Common;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api", 
        Justification = Justifications.SpecialSpelling)]
    public class WebApiBootstrapperTask : IBootstrapperTask
    {
        #region Public Methods and Operators

        public void Run(Bootstrapper bootstrapper)
        {
            if (bootstrapper == null)
            {
                throw new ArgumentNullException("bootstrapper");
            }

            RegisterRoutes(bootstrapper.HttpConfiguration);
        }

        #endregion

        #region Methods

        private static void RegisterRoutes(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}", 
                new
                    {
                        id = RouteParameter.Optional
                    });
        }

        #endregion
    }
}
