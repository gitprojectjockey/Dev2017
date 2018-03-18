using System.Collections.Generic;
using System.Web.Http;

namespace LinqToXmlFileWebApi.Controllers
{
    [RoutePrefix("Api/Customers")]
    public class CustomerController : ApiController
    {
        private readonly CustomerFileContext.ICustomerOrderFileService _customerOrderFileService;
        public CustomerController(CustomerFileContext.ICustomerOrderFileService customerOrderFileService)
        {
            _customerOrderFileService = customerOrderFileService;
        }
        
        [HttpGet,Route("Get")]
        public IEnumerable<CustomerFileContext.Customer> Get()
        {
            return _customerOrderFileService.Customers;
        }
      
        [HttpGet, Route("Get/{id}")]
        public CustomerFileContext.Customer Get(string id)
        {
            return _customerOrderFileService.Customer(id);
        }

        [HttpGet, Route("GetWithOrders/{id}")]
        public CustomerFileContext.Customer WithOrders(string id)
        {
            return _customerOrderFileService.CustomerWithOrders(id);
        }

        // POST
        public void Post([FromBody]string value)
        {
        }

        // PUT
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE
        public void Delete(int id)
        {
        }
    }
}
