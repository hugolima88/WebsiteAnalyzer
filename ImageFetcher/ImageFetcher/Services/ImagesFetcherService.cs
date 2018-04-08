using System.Collections.Generic;
using ImageFetcher.Models;
using System.Linq;
using System;
using ImageFetcher.Services.Wrappers;
using HtmlAgilityPack;

namespace ImageFetcher.Services
{
    /// <summary>
    /// Implements the methods to fetch all the images from the provided website.
    /// </summary>
    public class ImagesFetcherService : IImagesFetcherService
    {
        private readonly IHtmlWeb m_HtmlWeb;

        /// <summary>
        /// Creates an instance of <see cref="ImagesFetcherService"/>
        /// </summary>
        public ImagesFetcherService() :
            this(new HtmlWebWrapper())
        { }

        internal ImagesFetcherService(IHtmlWeb p_HtmlWeb)
        {
            m_HtmlWeb = p_HtmlWeb;
        }

        /// <summary>
        /// Fetchs all the images from the provided website.
        /// </summary>
        /// <param name="p_WebsiteUrl">The website URL.</param>
        /// <returns>All the images from the website.</returns>
        public IList<ImageModel> FetchImages(string p_WebsiteUrl)
        {
            var document = m_HtmlWeb.Load(p_WebsiteUrl);

            return document.DocumentNode.Descendants("img")
                                        .Select(element => element.GetAttributeValue("src", null))
                                        .Where(source => !String.IsNullOrEmpty(source))
                                        .Select(imageUrl => ForceAbsolutePath(imageUrl, p_WebsiteUrl))
                                        .Select(imageUrl => new ImageModel(imageUrl))
                                        .ToList();
        }

        private string ForceAbsolutePath(string p_ImageUrl,
                                         string p_WebsiteUrl)
        {
            if (!p_ImageUrl.ToLower().StartsWith("http://") && !p_ImageUrl.ToLower().StartsWith("https://"))
                return GetUrlRoot(p_WebsiteUrl) + "/" + p_ImageUrl.TrimStart('/');
            else
                return p_ImageUrl;
        }

        private string GetUrlRoot(string p_WebsiteUrl)
        {
            var uri = new Uri(p_WebsiteUrl);
            return uri.Scheme + "://" + uri.Host;
        }
    }
}