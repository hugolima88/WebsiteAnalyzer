using System.Collections.Generic;
using System.Linq;

namespace ImageFetcher.Models
{
    /// <summary>
    /// Represents the summary which contains a few relevant data extracted from the words on the provided website.
    /// </summary>
    public class WordsSummaryModel
    {
        /// <summary>
        /// Represents the total number of words present on the provided website.
        /// </summary>
        public int WordsCount { get; set; }

        /// <summary>
        /// Represents the total number of different words present on the provided website.
        /// </summary>
        public int DifferentWordsCount { get; set; }

        /// <summary>
        /// Represents an <see cref="IDictionary{TKey, TValue}"/> which maps each word present on the website to its total count of occurrences.
        /// </summary>
        public IDictionary<string, int> OccurringWordsDictionary { get; set; }

        /// <summary>
        /// Gets the K most frequent words on the dictionary.
        /// </summary>
        /// <param name="p_count">The number of most frenque words.</param>
        /// <returns>An instance of <see cref="IDictionary{TKey, TValue}"/> with the K most frequent words.</returns>
        public IDictionary<string, int> GetMostFrequentWords(int p_count)
        {
            if(OccurringWordsDictionary != null)
            {
                var items = from pair in OccurringWordsDictionary
                            orderby pair.Value descending
                            select pair;

                return items.Take(p_count)
                            .ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            else
            {
                return null;
            }
        }
    }
}