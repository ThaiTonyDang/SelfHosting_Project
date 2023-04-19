using SeftHosting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeftHosting
{
    public class ProductController : ApiController
    {
        private List<Product> _products = new List<Product>
        {
            new Product {Id = 1, Name = "Samsung"},
            new Product {Id = 2, Name = "Iphone"},
            new Product {Id = 3, Name = "Nokia"},
            new Product {Id = 4, Name = "Huwei"},
            new Product {Id = 5, Name = "S:"}
        };

        //api//products
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        // api/products/id
        public Product Get(int id)
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
        public HttpResponseMessage Post(Product product)
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
