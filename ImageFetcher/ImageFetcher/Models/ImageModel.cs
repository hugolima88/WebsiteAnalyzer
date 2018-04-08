namespace ImageFetcher.Models
{
    /// <summary>
    /// Represents a model of an image.
    /// </summary>
    public class ImageModel
    {
        /// <summary>
        /// Creates an instance of <see cref="ImageModel"/>.
        /// </summary>
        public ImageModel(string p_ImageUrl)
        {
            ImageUrl = p_ImageUrl;
        }

        /// <summary>
        /// Represents an image.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}