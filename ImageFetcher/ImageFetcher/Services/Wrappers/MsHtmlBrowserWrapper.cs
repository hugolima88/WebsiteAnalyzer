using WatiN.MsHtmlBrowser;
using WatiN.Core;

namespace ImageFetcher.Services.Wrappers
{
    /// <summary>
    /// Represents a wrapper to the <see cref="MsHtmlBrowser"/> class.
    /// </summary>
    public class MsHtmlBrowserWrapper : IMsHtmlBrowser
    {
        private readonly MsHtmlBrowser m_MsHtmlBrowser;

        /// <summary>
        /// Creates an instance of <see cref="MsHtmlBrowserWrapper"/>
        /// </summary>
        /// <param name="p_HtmlWeb"></param>
        public MsHtmlBrowserWrapper()
        {
            m_MsHtmlBrowser = new MsHtmlBrowser();
        }

        public string Text {
            get
            {
                return m_MsHtmlBrowser.Text;
            }
        }

        public void GoTo(string p_Url)
        {
            m_MsHtmlBrowser.GoTo(p_Url);
        }
    }
}