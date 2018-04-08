namespace ImageFetcher.Services.Wrappers
{
    /// <summary>
    /// Defines the methods of the <see cref="MsHtmlBrowser"/> class.
    /// </summary>
    public interface IMsHtmlBrowser
    {
        string Text { get; }

        void GoTo(string p_Url);
    }
}
