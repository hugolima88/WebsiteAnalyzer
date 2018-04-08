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
        private readonly IMsHtmlBrowser m_MsHtmlBrowser;

        /// <summary>
        /// Creates an instance of <see cref="WordsHandler"/>
        /// </summary>
        public WordsHandler() :
            this(new MsHtmlBrowserWrapper())
        { }

        internal WordsHandler(IMsHtmlBrowser p_MsHtmlBrowser)
        {
            m_MsHtmlBrowser = p_MsHtmlBrowser;
        }

        /// <summary>
        /// Gets the summary about the words for the provided website.
        /// </summary>
        /// <param name="p_WebsiteUrl">The provided website URL.</param>
        /// <returns></returns>
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
            // Here I'm using an external open source lib to get all the words on the provided website.
            // More information here: https://www.codeproject.com/Articles/587458/GettingplusOnlyplusTheplusTextplusDisplayedplusOnp
            m_MsHtmlBrowser.GoTo(p_WebsiteUrl);
            var text = m_MsHtmlBrowser.Text;
            if (!String.IsNullOrEmpty(text))
                return text.Replace("\r\n", " ");
            else
                return String.Empty;
        }
    }
}
