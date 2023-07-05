using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net;
using WescrapDataprj_1.web.Models;

namespace WescrapDataprj_1.web.Controllers
{
    public class OffersController : Controller
    {
        public IActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var jobs = new List<Job>();

            var web = new HtmlWeb();
                var doc = web.Load("https://www.emploitic.com/offres-d-emploi");

            foreach (var item in doc.DocumentNode.SelectNodes("//div[@class='row-fluid job-details pointer']"))
            {
                string title = item.SelectSingleNode(".//h2").InnerText.Trim();
                string details = item.SelectSingleNode(".//a").GetAttributeValue("href", null).Trim();
                string img = item.SelectSingleNode(".//img").GetAttributeValue("src", null).Trim();
                jobs.Add(new Job()
                {
                    Title = title,  
                    Details = details,  
                    Img = img
                });

            }
            return View(jobs);
        }
    }
}
