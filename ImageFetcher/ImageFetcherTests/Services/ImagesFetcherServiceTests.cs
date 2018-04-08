using NUnit.Framework;
using ImageFetcher.Services;
using Moq;
using ImageFetcher.Services.Wrappers;
using HtmlAgilityPack;

namespace ImageFetcherTests.Services
{
    [TestFixture]
    public class ImagesFetcherServiceTests
    {
        private const string WEBSITE = "http://www.mywebsite.com";

        private Mock<IHtmlWeb> m_HtmlWebMok;

        private ImagesFetcherService m_ImagesFetcherService;

        [SetUp]
        public void Setup()
        {
            m_HtmlWebMok = new Mock<IHtmlWeb>();

            m_ImagesFetcherService = new ImagesFetcherService(m_HtmlWebMok.Object);
        }

        [Test]
        public void FetchImages_GivenWebsiteHasNoImages_ExpectEmptyList()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml("<html><body><h1>My First Heading</h1><p>My first paragraph.</p></body></html>");

            m_HtmlWebMok.Setup(htmlWeb => htmlWeb.Load(WEBSITE))
                               .Returns(() => htmlDocument);

            var fetchedImages = m_ImagesFetcherService.FetchImages(WEBSITE);

            Assert.That(fetchedImages, Is.Empty);
        }

        [Test]
        public void FetchImages_GivenWebsiteHasImagesWithRelativePath_ExpectListWithAbsoluteImagesUrlPaths()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml("<html><body><img src='xcentium1.jpg'><img src='/xcentium2.jpg'></body></html>");

            m_HtmlWebMok.Setup(htmlWeb => htmlWeb.Load(WEBSITE))
                        .Returns(() => htmlDocument);

            var fetchedImages = m_ImagesFetcherService.FetchImages(WEBSITE);

            Assert.That(fetchedImages.Count, Is.EqualTo(2));
            Assert.That(fetchedImages[0].ImageUrl, Is.EqualTo(WEBSITE + "/xcentium1.jpg"));
            Assert.That(fetchedImages[1].ImageUrl, Is.EqualTo(WEBSITE + "/xcentium2.jpg"));
        }

        [Test]
        public void FetchImages_GivenWebsiteHasImagesWithAbsolutePath_ExpectListWithAbsoluteImagesUrlPaths()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml("<html><body><img src='http://www.mywebsite.com/xcentium1.jpg'><img src='http://www.mywebsite.com/xcentium2.jpg'></body></html>");

            m_HtmlWebMok.Setup(htmlWeb => htmlWeb.Load(WEBSITE))
                        .Returns(() => htmlDocument);

            var fetchedImages = m_ImagesFetcherService.FetchImages(WEBSITE);

            Assert.That(fetchedImages.Count, Is.EqualTo(2));
            Assert.That(fetchedImages[0].ImageUrl, Is.EqualTo(WEBSITE + "/xcentium1.jpg"));
            Assert.That(fetchedImages[1].ImageUrl, Is.EqualTo(WEBSITE + "/xcentium2.jpg"));
        }
    }
}
