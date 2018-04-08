using System.Collections.Generic;
using ImageFetcher.Models;

namespace ImageFetcher.Services
{
    /// <summary>
    /// Defines the methods to fetch all the images from the provided website.
    /// </summary>
    public interface IImagesFetcherService
    {
        /// <summary>
        /// Fetchs all the images from the provided website.
        /// </summary>
        /// <param name="p_WebsiteUrl">The website URL.</param>
        /// <returns>All the images from the website.</returns>
        IList<ImageModel> FetchImages(string p_WebsiteUrl);
    }
}
