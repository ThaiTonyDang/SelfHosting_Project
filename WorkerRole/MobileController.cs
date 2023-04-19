using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WorkerRole.Model;

namespace WorkerRole
{
    public class MobileController : ApiController
    {
        private List<Mobile> _products = new List<Mobile>
        {
            new Mobile {Id = 1, Name = "Samsung"},
            new Mobile {Id = 2, Name = "Iphone"},
            new Mobile {Id = 3, Name = "Nokia"},
            new Mobile {Id = 4, Name = "Huwei"},
            new Mobile {Id = 5, Name = "S:"}
        };

        //api//products
        public IEnumerable<Mobile> Get()
        {
            return _products;
        }

        // api/products/id
        public Mobile Get(int id)
        {
            var product = _products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(
                    System.Net.HttpStatusCode.NotFound);
            }
            return product;
        }

        [HttpPost]
        public HttpResponseMessage Post(Mobile product)
        {
            try
            {
                _products.Add(product);
                return Request.CreateResponse(HttpStatusCode.OK, _products);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
           
        }
    }
}
