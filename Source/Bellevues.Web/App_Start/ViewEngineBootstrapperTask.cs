// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewEngineBootstrapperTask.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the ViewEngineBootstrapperTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    using Bellevues.Common;

    public class ViewEngineBootstrapperTask // : IBootstrapperTask
    {
        #region Public Methods and Operators

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = Justifications.TemporaryDesign)]
        public void Run(Bootstrapper bootstrapper)
        {
            if (bootstrapper == null)
            {
                throw new ArgumentNullException("bootstrapper");
            }

            RegisterViewEngine(bootstrapper.ViewEngineCollection);
        }

        #endregion

        #region Methods

        private static void RegisterViewEngine(ViewEngineCollection viewEngines)
        {
            RazorViewEngine viewRngine = new RazorViewEngine()
                                             {
                                                 MasterLocationFormats = new[]
                                                                             {
                                                                                 "~/Views/{1}/{0}.master", "~/Views/{0}.master"
                                                                             }, 
                                                 ViewLocationFormats = new[]
                                                                           {
                                                                               "~/Views/{1}/{0}.aspx", "~/Views/{1}/{0}.ascx", 
                                                                               "~/Views/{0}.aspx", "~/Views/{0}.ascx"
                                                                           }, 
                                                 PartialViewLocationFormats = new[]
                                                                                  {
                                                                                      "~/Views/{1}/{0}.aspx", "~/Views/{1}/{0}.ascx", 
                                                                                      "~/Views/{0}.aspx", "~/Views/{0}.ascx"
                                                                                  }
                                             };

            viewEngines.Clear();
            viewEngines.Add(viewRngine);
        }

        #endregion
    }
}
