using System.Diagnostics;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message, GenericData.MessageTypes? messageType)
        {
            if (messageType != null || !message.IsNullOrWhiteSpace())
            {
                ViewBag.StatusMessage = message;
                ViewBag.MessageTypeClass = GenericData.MessageTypeClass((GenericData.MessageTypes)messageType);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}