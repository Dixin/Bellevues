// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MefControllerFactory.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the MefControllerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.Controllers
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    internal class MefControllerFactory : DefaultControllerFactory
    {
        #region Constants and Fields

        private readonly CompositionContainer container;

        #endregion

        #region Constructors and Destructors

        public MefControllerFactory(CompositionContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Methods

        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null || !typeof(IController).IsAssignableFrom(controllerType))
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            Lazy<object, object> controllerExport = this.container.GetExports(controllerType, null, null).SingleOrDefault();
            return controllerExport == null ? null : controllerExport.Value as IController;
        }

        #endregion
    }
}