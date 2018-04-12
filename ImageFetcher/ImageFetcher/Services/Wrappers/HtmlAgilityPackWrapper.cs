using HtmlAgilityPack;
using System.Text;

namespace ImageFetcher.Services.Wrappers
{
    /// <summary>
    /// Represents a wrapper of the methods present on the HtmlAgilityPack lib.
    /// </summary>
    public class HtmlAgilityPackWrapper : IHtmlAgilityPackWrapper
    {
        /// <summary>
        /// Gets all visible text from a provided url.
        /// </summary>
        /// <param name="p_Url">The requested URL.</param>
        /// <returns>The visible text.</returns>
        public string GetVisibleText(string p_Url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(p_Url);

            var sb = new StringBuilder();
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//text()"))
            {
                if (!node.ParentNode.Name.Equals("script") &&
                    !node.ParentNode.Name.Equals("style") &&
                    !node.InnerHtml.Equals("\r\n") &&
                    !string.IsNullOrEmpty(node.InnerHtml.Trim()))
                    sb.Append(node.InnerHtml + " ");
            }

            return sb.ToString();
        }
    }
}