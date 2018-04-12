using System.Collections.Generic;
using ImageFetcher.Models;
using WatiN.MsHtmlBrowser;
using WatiN.Core;
using System.Linq;
using ImageFetcher.Services.Wrappers;
using System;

namespace ImageFetcher.Services
{
    /// Implements the methods to get a summary about the words for the provided website.
    public class WordsHandler : IWordsHandler
    {
        private readonly IHtmlAgilityPackWrapper m_HtmlAgilityPackWrapper;

        /// <summary>
        /// Creates an instance of <see cref="WordsHandler"/>.
        /// </summary>
        public WordsHandler() :
            this(new HtmlAgilityPackWrapper())
        { }

        internal WordsHandler(IHtmlAgilityPackWrapper p_HtmlAgilityPackWrapper)
        {
            m_HtmlAgilityPackWrapper = p_HtmlAgilityPackWrapper;
        }

        /// <summary>
        /// Gets the summary about the words for the provided website.
        /// </summary>
        /// <param name="p_WebsiteUrl">The provided website URL.</param>
        /// <returns>An instance of <see cref="WordsSummaryModel"/>.</returns>
        public WordsSummaryModel GetWordsSummary(string p_WebsiteUrl)
        {
            var wordsSummary = new WordsSummaryModel();

            var allWords = GetAllWords(p_WebsiteUrl);

            if(allWords != null && allWords.Any())
            {
                var wordsDictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

                foreach (string word in allWords)
                {
                    if (wordsDictionary.ContainsKey(word))
                        wordsDictionary[word]++;
                    else
                        wordsDictionary.Add(word, 1);
                }

                wordsSummary = new WordsSummaryModel
                {
                    OccurringWordsDictionary = wordsDictionary,
                    DifferentWordsCount = wordsDictionary.Keys.Count,
                    WordsCount = allWords.Count
                };
            }

            return wordsSummary;
        }

        private IList<string> GetAllWords(string p_WebsiteUrl)
        {
            return GetVisibleText(p_WebsiteUrl).Split(' ')
                                               .Where(word => !string.IsNullOrWhiteSpace(word))
                                               .ToList();
        }

        private string GetVisibleText(string p_WebsiteUrl)
        {
            return m_HtmlAgilityPackWrapper.GetVisibleText(p_WebsiteUrl);
        }
    }
}
