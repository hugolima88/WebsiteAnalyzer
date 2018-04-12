using System;
using NUnit.Framework;
using ImageFetcher.Services;
using Moq;
using ImageFetcher.Services.Wrappers;

namespace ImageFetcherTests.Services
{
    [TestFixture]
    public class WordsHandlerTests
    {
        private const string WEBSITE = "www.mywebsite.com";
        private const string WEBSITE_VALID_TEXT = "a a a a a a b b b b b c c c c e e e e r t g d d d b f f f f";

        private Mock<IHtmlAgilityPackWrapper> m_HtmlAgilityPackWrapperMock;

        private WordsHandler m_WordsHandler;

        [SetUp]
        public void Setup()
        {
            m_HtmlAgilityPackWrapperMock = new Mock<IHtmlAgilityPackWrapper>();

            m_WordsHandler = new WordsHandler(m_HtmlAgilityPackWrapperMock.Object);
        }

        [Test]
        public void GetWordsSummary_GivenWebsiteTextIsEmpty_ExpectEmptySummary()
        {
            m_HtmlAgilityPackWrapperMock.Setup(wrapper => wrapper.GetVisibleText(WEBSITE))
                                        .Returns(String.Empty);

            var wordSummary = m_WordsHandler.GetWordsSummary(WEBSITE);

            Assert.That(wordSummary.WordsCount, Is.EqualTo(0));
            Assert.That(wordSummary.OccurringWordsDictionary, Is.Null);
        }

        [Test]
        public void GetWordsSummary_GivenWebsiteTextIsValid_ExpectValidSummary()
        {
            m_HtmlAgilityPackWrapperMock.Setup(wrapper => wrapper.GetVisibleText(WEBSITE))
                                        .Returns(WEBSITE_VALID_TEXT);

            var wordSummary = m_WordsHandler.GetWordsSummary(WEBSITE);
            var threeMostFrequentWords = wordSummary.GetMostFrequentWords(3);

            Assert.That(wordSummary.WordsCount, Is.EqualTo(30));
            Assert.That(wordSummary.DifferentWordsCount, Is.EqualTo(9));
            Assert.That(wordSummary.OccurringWordsDictionary["a"], Is.EqualTo(6));
            Assert.That(threeMostFrequentWords["a"], Is.EqualTo(6));
            Assert.That(threeMostFrequentWords["b"], Is.EqualTo(6));
            Assert.That(threeMostFrequentWords["c"], Is.EqualTo(4));
        }
    }
}
