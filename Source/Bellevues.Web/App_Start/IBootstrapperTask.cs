// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBootstrapperTask.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the IBootstrapperTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Web.App_Start
{
    public interface IBootstrapperTask
    {
        #region Public Methods and Operators

        void Run(Bootstrapper bootstrapper);

        #endregion
    }
}