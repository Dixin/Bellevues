// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterBootstrapperTask.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the FilterBootstrapperTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    using System;
    using System.ComponentModel.Composition;
    using System.Web.Mvc;

    [Export(typeof(IBootstrapperTask))]
    public class FilterBootstrapperTask : IBootstrapperTask
    {
        #region Public Methods and Operators

        public void Run(Bootstrapper bootstrapper)
        {
            if (bootstrapper == null)
            {
                throw new ArgumentNullException("bootstrapper");
            }

            RegisterGlobalFilters(bootstrapper.GlobalFilterCollection);
        }

        #endregion

        #region Methods

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }
}
