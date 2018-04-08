using ImageFetcher.Models;

namespace ImageFetcher.Services
{
    /// Implements the methods to gerenate a full report for the provided website.
    public class ReportGeneratorService : IReportGeneratorService
    {
        private readonly IImagesFetcherService m_ImagesFetcherService;
        private readonly IWordsHandler m_WordsHandler;

        /// <summary>
        /// Creates an instance of <see cref="ReportGeneratorService"/>
        /// </summary>
        public ReportGeneratorService() :
            this(new ImagesFetcherService(),
                 new WordsHandler())
        { }

        internal ReportGeneratorService(IImagesFetcherService p_ImagesFetcherService,
                                        IWordsHandler p_WordsHandler)
        {
            m_ImagesFetcherService = p_ImagesFetcherService;
            m_WordsHandler = p_WordsHandler;
        }

        /// <summary>
        /// Generates a full report for the provided website.
        /// </summary>
        /// <param name="p_WebsiteUrl">The provided website URL.</param>
        /// <returns>An instance of <see cref="FullReportModel"/> </returns>
        public FullReportModel GenerateReport(string p_WebsiteUrl)
        {
            var report = new FullReportModel
            {
                WebsiteUrl = p_WebsiteUrl,
                ImagesCarousel = new ImagesCarouselModel
                {
                    Images = m_ImagesFetcherService.FetchImages(p_WebsiteUrl)
                },
                WordsSummary = m_WordsHandler.GetWordsSummary(p_WebsiteUrl)
            };

            return report;
        }
    }
}