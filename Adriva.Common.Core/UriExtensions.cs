﻿using System;
using System.Text;

namespace Adriva.Common.Core
{
    public static class UriExtensions
    {
        public static string GetBase(this Uri startUri)
        {
            StringBuilder sb = new StringBuilder(startUri.Scheme + "://");

            if (!String.IsNullOrEmpty(startUri.UserInfo))
                sb.Append(startUri.UserInfo + "@");

            sb.Append(startUri.Host);

            if (startUri.Port != 80 && startUri.Port != 443)
                sb.Append(":" + startUri.Port);

            return sb.ToString();
        }

        public static string GetPathBase(this Uri startUri)
        {
            return UriExtensions.GetBase(startUri)
                + startUri.AbsolutePath.Substring(0, startUri.AbsolutePath.LastIndexOf("/", StringComparison.Ordinal) + 1);
        }

        public static string ToAbsoluteURI(this Uri pageUri, string uriToCheck)
        {
            var scheme = pageUri.Scheme;
            var prePath = UriExtensions.GetBase(pageUri);
            var pathBase = UriExtensions.GetPathBase(pageUri);

            // If this is already an absolute URI, return it.
            if (Uri.IsWellFormedUriString(uriToCheck, UriKind.Absolute))
                return uriToCheck;

            // Ignore hash URIs
            if ('#' == uriToCheck[0])
                return uriToCheck;

            // Scheme-rooted relative URI.
            if (1 < uriToCheck.Length && uriToCheck.Substring(0, 2).Equals("//", StringComparison.Ordinal))
                return scheme + "://" + uriToCheck.Substring(2);

            // Prepath-rooted relative URI.
            if ('/' == uriToCheck[0])
                return prePath + uriToCheck;

            // Dotslash relative URI.
            if (0 == uriToCheck.IndexOf("./", StringComparison.Ordinal))
                return pathBase + uriToCheck.Substring(2);

            // Standard relative URI; add entire path. pathBase already includes a
            // trailing "/".
            return pathBase + uriToCheck;
        }
    }
}
