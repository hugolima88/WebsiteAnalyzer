using HtmlAgilityPack;

namespace ImageFetcher.Services.Wrappers
{
    /// <summary>
    /// Defines the methods of an instance of <see cref="HtmlWeb"/>
    /// </summary>
    public interface IHtmlWeb
    {
        HtmlDocument Load(string p_Url);
    }
}