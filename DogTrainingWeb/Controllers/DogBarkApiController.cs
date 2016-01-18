using System.Collections.Generic;
using System.Web.Http;
using DogTrainingWeb.Models;

namespace DogTrainingWeb.Controllers
{
    public class DogBarkApiController : ApiController
    {
        /// <summary>
        /// Gets all barks.
        /// </summary>
        [HttpGet]
        public IEnumerable<DogBarkModel> GetAll()
        {
            return DogBarkContext.Instance.GetAll();
        }

        /// <summary>
        /// Gets latest bark.
        /// </summary>
        [HttpGet]
        public DogBarkModel GetLatest()
        {
            return DogBarkContext.Instance.GetLatest();
        }
    }
}
