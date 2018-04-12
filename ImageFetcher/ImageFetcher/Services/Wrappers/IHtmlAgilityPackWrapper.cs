using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageFetcher.Services.Wrappers
{
    /// <summary>
    /// Defines a wrapper of the methods present on the HtmlAgilityPack lib.
    /// </summary>
    public interface IHtmlAgilityPackWrapper
    {
        /// <summary>
        /// Gets all visible text from a provided url.
        /// </summary>
        /// <param name="p_Url">The requested URL.</param>
        /// <returns>The visible text.</returns>
        string GetVisibleText(string p_Url);
    }
}