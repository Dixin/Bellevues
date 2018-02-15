// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the Bootstrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Bellevues.Common;

    public class Bootstrapper
    {
        #region Constructors and Destructors

        internal Bootstrapper()
        {
            this.CompositionContainer = GetContainer();
        }

        #endregion

        #region Properties

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = Justifications.ByDesign)]
        internal BundleCollection BundleCollection
        {
            get
            {
                return BundleTable.Bundles;
            }
        }

        internal CompositionContainer CompositionContainer
        {
            get;
            private set;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = Justifications.ByDesign)]
        internal GlobalFilterCollection GlobalFilterCollection
        {
            get
            {
                return GlobalFilters.Filters;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = Justifications.ByDesign)]
        internal HttpConfiguration HttpConfiguration
        {
            get
            {
                return GlobalConfiguration.Configuration;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = Justifications.ByDesign)]
        internal RouteCollection RouteCollection
        {
            get
            {
                return RouteTable.Routes;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = Justifications.ByDesign)]
        internal ViewEngineCollection ViewEngineCollection
        {
            get
            {
                return ViewEngines.Engines;
            }
        }

        #endregion

        #region Methods

        internal void Run()
        {
            this.CompositionContainer.GetExportedValues<IBootstrapperTask>().ForEach(task => task.Run(this));
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = Justifications.ByDesign)]
        private static CompositionContainer GetContainer()
        {
            string file = Assembly.GetExecutingAssembly().CodeBase;
            string directory = Path.GetDirectoryName(new Uri(file).LocalPath);
            return new CompositionContainer(new DirectoryCatalog(directory));
        }

        #endregion
    }
}
