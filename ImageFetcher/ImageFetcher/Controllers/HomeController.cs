using System;
using System.Web.Mvc;
using ImageFetcher.Services;

namespace ImageFetcher.Controllers
{
    /// <summary>
    /// Represents the basic controler of this web application.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IReportGeneratorService m_ReportGeneratorService;

        /// <summary>
        /// Creates an instance of <see cref="HomeController"/>
        /// </summary>
        public HomeController() :
            this(new ReportGeneratorService())
        { }

        internal HomeController(IReportGeneratorService p_ReportGeneratorService)
        {
            m_ReportGeneratorService = p_ReportGeneratorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FullReport()
        {
            return RedirectToAction("Index");
        }

        [HttpGet, Route("~/Error")]
        public  ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FullReport(string websiteUrl)
        {
            if(!String.IsNullOrEmpty(websiteUrl))
            {
                try
                {
                    var reportModel = m_ReportGeneratorService.GenerateReport(SanitizeUrl(websiteUrl));
                    return View("FullReport", reportModel);
                }
                catch(Exception exception)
                {
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        private string SanitizeUrl(string p_Url)
        {
            var url = p_Url;

            if(!p_Url.ToLower().StartsWith("http://") && !p_Url.ToLower().StartsWith("https://"))
                url = "http://" + url;

            if (url.EndsWith("/"))
                url = url.TrimEnd('/');

            return url;
        }
    }
}