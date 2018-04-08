using ImageFetcher.Models;

namespace ImageFetcher.Services
{
    /// <summary>
    /// Defines the methods to gerenate a full report for the provided website.
    /// </summary>
    public interface IReportGeneratorService
    {
        /// <summary>
        /// Generates a full report for the provided website.
        /// </summary>
        /// <param name="p_WebsiteUrl">The provided website URL.</param>
        /// <returns>An instance of <see cref="FullReportModel"/> </returns>
        FullReportModel GenerateReport(string p_WebsiteUrl);
    }
}
