using System.Collections.Generic;
using System.Web.Http;
using DogTrainingWeb.Models;

namespace DogTrainingWeb.Controllers
{
    public class DogBarkApiController : ApiController
    {
        private static readonly DogBarkContext _DbContext = new DogBarkContext();

        /// <summary>
        /// Gets all barks.
        /// </summary>
        [HttpGet]
        public IEnumerable<DogBarkModel> GetAll()
        {
            return _DbContext.GetAll();
        }

        /// <summary>
        /// Gets latest bark.
        /// </summary>
        [HttpGet]
        public DogBarkModel GetLatest()
        {
            return _DbContext.GetLatest();
        }

        /// <summary>
        /// Post new bark.
        /// </summary>
        public void Post([FromBody]DogBarkViewModel value)
        {
            _DbContext.Create(value);
        }
    }
}
