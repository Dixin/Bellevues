// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerFactoryBootstrapperTask.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the ControllerFactoryBootstrapperTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    using System;
    using System.ComponentModel.Composition;
    using System.Web.Mvc;

    using Bellevues.Web.Controllers;

    [Export(typeof(IBootstrapperTask))]
    public class ControllerFactoryBootstrapperTask : IBootstrapperTask
    {
        #region Public Methods and Operators

        public void Run(Bootstrapper bootstrapper)
        {
            if (bootstrapper == null)
            {
                throw new ArgumentNullException("bootstrapper");
            }

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(bootstrapper.CompositionContainer));
        }

        #endregion
    }
}