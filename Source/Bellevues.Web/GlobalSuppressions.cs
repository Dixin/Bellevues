// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Bellevues.com" file="GlobalSuppressions.cs">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   GlobalSuppressions.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

using Bellevues.Common;

[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = Justifications.NotSupported)]

[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Bellevues", Justification = Justifications.SpecialSpelling)]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Bellevues", Scope = "namespace", Target = "Bellevues.Web", Justification = Justifications.SpecialSpelling)]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Bellevues", Scope = "namespace", Target = "Bellevues.Web.App_Start", Justification = Justifications.SpecialSpelling)]
[assembly: SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Scope = "namespace", Target = "Bellevues.Web.App_Start", Justification = Justifications.SpecialSpelling)]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Bellevues", Scope = "namespace", Target = "Bellevues.Web.Views", Justification = Justifications.SpecialSpelling)]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Bellevues", Scope = "namespace", Target = "Bellevues.Web.Models", Justification = Justifications.SpecialSpelling)]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Bellevues", Scope = "namespace", Target = "Bellevues.Web.Controllers", Justification = Justifications.SpecialSpelling)]

[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Bellevues.Web", Justification = Justifications.ByDesign)]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Bellevues.Web.Controllers", Justification = Justifications.ByDesign)]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Bellevues.Web.Models", Justification = Justifications.ByDesign)]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Bellevues.Web.Views", Justification = Justifications.ByDesign)]
