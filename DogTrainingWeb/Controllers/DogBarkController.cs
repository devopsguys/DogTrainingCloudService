using DogTrainingWeb.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace DogTrainingWeb.Controllers
{
    public class DogBarkController : Controller
    {
        private static readonly DogBarkContext _DbContext = new DogBarkContext();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.DogTrainingWebVersion = ConfigurationManager.AppSettings["DogTrainingWebVersion"];

            var allBarks = _DbContext.GetAll().Select(bark => new DogBarkViewModel(bark));
            return View(allBarks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogBarkViewModel model)
        {
            _DbContext.Create(model);
            return RedirectToAction("Index");
        }
    }
}