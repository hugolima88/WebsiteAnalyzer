using ImageFetcher.Models;

namespace ImageFetcher.Services
{
    /// <summary>
    /// Defines the methods to get a summary about the words for the provided website.
    /// </summary>
    public interface IWordsHandler
    {
        /// <summary>
        /// Gets the summary about the words for the provided website.
        /// </summary>
        /// <param name="p_WebsiteUrl">The provided website URL.</param>
        /// <returns></returns>
        WordsSummaryModel GetWordsSummary(string p_WebsiteUrl);
    }
}
