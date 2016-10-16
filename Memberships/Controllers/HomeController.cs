using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity; // Needed for HttpContext Identity
using Memberships.Extensions; // Needed for your extension methods
using Memberships.Models;
using System.Threading.Tasks;

namespace Memberships.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var userId = Request.IsAuthenticated ? HttpContext.User.Identity.GetUserId() : null;
            var thumbnails = await new List<ThumbnailModel>().GetProductThumbnailsAsync(userId);            var count = thumbnails.Count() / 4;
            var model = new List<ThumbnailAreaModel>();
            for (int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailAreaModel
                {
                    Title = i.Equals(0) ? "My Content" : String.Empty,
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
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