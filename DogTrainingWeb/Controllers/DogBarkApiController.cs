using System.Collections.Generic;
using System.Web.Http;
using DogTrainingWeb.Models;

namespace DogTrainingWeb.Controllers
{
    public class DogBarkApiController : ApiController
    {
        // GET: api/Api
        public IEnumerable<DogBarkModel> Get()
        {
            return DogBarkContext.Instance.GetAllApi();
        }

        // GET: api/Api/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Api
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Api/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Api/5
        public void Delete(int id)
        {
        }
    }
}
