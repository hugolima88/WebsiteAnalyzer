using NUnit.Framework;
using ImageFetcher.Services;
using Moq;
using ImageFetcher.Models;
using System.Collections.Generic;

namespace ImageFetcherTests.Services
{
    [TestFixture]
    public class ReportGeneratorServiceTests
    {
        private const string WEBSITE = "http://www.mywebsite.com";

        private Mock<IImagesFetcherService> m_ImagesFetcherServiceMock;
        private Mock<IWordsHandler> m_WordsHandlerMock;

        private ReportGeneratorService m_ReportGeneratorService;

        [SetUp]
        public void Setup()
        {
            m_ImagesFetcherServiceMock = new Mock<IImagesFetcherService>();
            m_WordsHandlerMock = new Mock<IWordsHandler>();

            m_ReportGeneratorService = new ReportGeneratorService(m_ImagesFetcherServiceMock.Object,
                                                                  m_WordsHandlerMock.Object);
        }

        [Test]
        public void GenerateReport_GivenValidWebsiteUrl_ExpectValidGenetaredReport()
        {
            var images = new List<ImageModel>
            {
                new ImageModel("imageA"),
                new ImageModel("imageB")
            };

            var wordsSummary = new WordsSummaryModel
            {
                DifferentWordsCount = 2,
                WordsCount = 5,
                OccurringWordsDictionary = new Dictionary<string, int>
                {
                    { "a", 3 },
                    { "b", 2 }

                }
            };

            m_ImagesFetcherServiceMock.Setup(imageFetcher => imageFetcher.FetchImages(WEBSITE))
                                      .Returns(images);

            m_WordsHandlerMock.Setup(wordsHandler => wordsHandler.GetWordsSummary(WEBSITE))
                              .Returns(wordsSummary);

            var fullReport = m_ReportGeneratorService.GenerateReport(WEBSITE);

            Assert.That(fullReport.ImagesCarousel.Images.Count, Is.EqualTo(images.Count));
            Assert.That(fullReport.ImagesCarousel.Images[0], Is.EqualTo(images[0]));
            Assert.That(fullReport.ImagesCarousel.Images[1], Is.EqualTo(images[1]));

            Assert.That(fullReport.WordsSummary.DifferentWordsCount, Is.EqualTo(wordsSummary.DifferentWordsCount));
            Assert.That(fullReport.WordsSummary.WordsCount, Is.EqualTo(wordsSummary.WordsCount));
            Assert.That(fullReport.WordsSummary.OccurringWordsDictionary.Count, Is.EqualTo(wordsSummary.OccurringWordsDictionary.Count));
        }
    }
}
