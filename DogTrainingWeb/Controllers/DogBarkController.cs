using DogTrainingWeb.Models;
using System.Configuration;
using System.Web.Mvc;

namespace DogTrainingWeb.Controllers
{
    public class DogBarkController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.DogTrainingWebVersion = ConfigurationManager.AppSettings["DogTrainingWebVersion"];
            return View(DogBarkContext.Instance.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogBarkViewModel model)
        {
            DogBarkContext.Instance.Create(model);
            return RedirectToAction("Index");
        }
    }
}