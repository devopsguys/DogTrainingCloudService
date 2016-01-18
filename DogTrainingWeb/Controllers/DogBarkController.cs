using DogTrainingWeb.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace DogTrainingWeb.Controllers
{
    public class DogBarkController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.DogTrainingWebVersion = ConfigurationManager.AppSettings["DogTrainingWebVersion"];

            var allBarks = DogBarkContext.Instance.GetAll().Select(bark => new DogBarkViewModel(bark));
            return View(allBarks);
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