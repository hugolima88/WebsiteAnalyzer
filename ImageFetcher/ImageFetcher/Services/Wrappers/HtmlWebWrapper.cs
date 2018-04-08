using HtmlAgilityPack;

namespace ImageFetcher.Services.Wrappers
{
    /// <summary>
    /// Represents a wrapper of an instance of <see cref="HtmlWeb"/>
    /// </summary>
    public class HtmlWebWrapper : IHtmlWeb
    {
        private readonly HtmlWeb m_HtmlWeb;

        /// <summary>
        /// Creates an instance of <see cref="HtmlWebWrapper"/>
        /// </summary>
        public HtmlWebWrapper()
        {
            m_HtmlWeb = new HtmlWeb();
        }

        /// <summary>
        /// Gets an HTML document from an Internet resource.
        /// </summary>
        /// <param name="p_Url">The requested URL.</param>
        /// <returns>The new html document.</returns>
        public HtmlDocument Load(string p_Url)
        {
            return m_HtmlWeb.Load(p_Url);
        }
    }
}