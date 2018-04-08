using System.Collections.Generic;

namespace ImageFetcher.Models
{
    /// <summary>
    /// Represents a carousel of images.
    /// </summary>
    public class ImagesCarouselModel
    {
        /// <summary>
        /// Represents an <see cref="IList{T}"/> of <see cref="ImageModel"/>.
        /// </summary>
        public IList<ImageModel> Images { get; set; }
    }
}