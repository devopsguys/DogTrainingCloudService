using System.Collections.Generic;
using System.Web.Http;
using DogTrainingWeb.Models;

namespace DogTrainingWeb.Controllers
{
    public class DogBarkApiController : ApiController
    {
        private readonly DogBarkContext DbContext = new DogBarkContext();

        /// <summary>
        /// Gets all barks.
        /// </summary>
        [HttpGet]
        public IEnumerable<DogBarkModel> GetAll()
        {
            return DbContext.GetAll();
        }

        /// <summary>
        /// Gets latest bark.
        /// </summary>
        [HttpGet]
        public DogBarkModel GetLatest()
        {
            return DbContext.GetLatest();
        }
    }
}
