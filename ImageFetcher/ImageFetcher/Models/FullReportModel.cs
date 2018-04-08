namespace ImageFetcher.Models
{
    /// <summary>
    /// Represents a full report with relevant information about the words and images present on a provided website.
    /// </summary>
    public class FullReportModel
    {
        /// <summary>
        /// Represents the website URL that generated the current report.
        /// </summary>
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// /Represents an instance of <see cref="ImagesCarouselModel"/>
        /// </summary>
        public ImagesCarouselModel ImagesCarousel { get; set; }

        /// <summary>
        /// Represents an instance of <see cref="WordsSummaryModel"/>
        /// </summary>
        public WordsSummaryModel WordsSummary { get; set; }

    }
}