// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the StringExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bellevues.Common
{
    using System;
    using System.Globalization;

    public static class StringExtensions
    {
        #region Public Methods and Operators

        public static string FormatInvariant(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }

        public static string Left(this string value, int count)
        {
            return string.IsNullOrEmpty(value) || count < 1 ? string.Empty : value.Substring(0, Math.Min(count, value.Length));
        }

        #endregion
    }
}