// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Bellevues.com">
//   Copyright (c) Bellevues.com. All rights reserved.
// </copyright>
// <summary>
//   Defines the MvcApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.IO;

namespace Bellevues.Web
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web;

    using Bellevues.Common;
    using Bellevues.Web.App_Start;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class Global : HttpApplication
    {
        #region Methods

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = Justifications.RequiredByFramework)]
        protected void Application_Start()
        {
            new Bootstrapper().Run();
        }

        protected void Application_BeginRequest()
        {
            Trace.TraceInformation(this.Context.Request.ToRaw());
        }

        #endregion
    }

    public static class HttpRequestExtensions
    {
        public static string ToRaw(this HttpRequest request)
        {
            using (StringWriter writer = new StringWriter())
            {
                WriteStartLine(request, writer);
                WriteHeaders(request, writer);
                WriteBody(request, writer);

                return writer.ToString();
            }
        }

        private static void WriteStartLine(HttpRequest request, StringWriter writer)
        {
            const string space = " ";

            writer.Write(request.HttpMethod);
            writer.Write(space);
            writer.Write(request.Url);
            writer.Write(space);
            writer.Write(request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress);
            writer.Write(space);
            writer.WriteLine(request.ServerVariables["SERVER_PROTOCOL"]);
        }

        private static void WriteHeaders(HttpRequest request, StringWriter writer)
        {
            foreach (string key in request.Headers.AllKeys)
            {
                writer.WriteLine($"{key}: {request.Headers[key]}");
            }

            writer.WriteLine();
        }

        private static void WriteBody(HttpRequest request, StringWriter writer)
        {
            using (StreamReader reader = new StreamReader(request.InputStream))
            {
                try
                {
                    string body = reader.ReadToEnd();
                    writer.WriteLine(body);
                }
                finally
                {
                    reader.BaseStream.Position = 0;
                }
            }
        }
    }
}
