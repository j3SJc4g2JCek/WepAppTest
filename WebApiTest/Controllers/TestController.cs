using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    // [AuthorizeToken]
    // If using token authentication, dress controller with this attribute which si going to be something to look at the current context and the headers to retreive a token to
    // verify requestor is allowed to access this. 
    public class TestController : ApiController
    {
        // GET: api/Test
        public async Task<IHttpActionResult> GetRecentPaymentRecords()
        {
            // Call service that contains TestModel repository for handling all TestModel related items
            //return await TestModelService.GetRecentTestModels(); // Note maybe this would have a lookback date, or customer, or something along those lines

            // Get our 3 most recent

            var testModels = new List<TestModel>();
            testModels.Add(new TestModel { TestId = 3, TestAmount = 24.56m, TestDescription = "Something longest", TestName = "Test of Tests 3" });
            testModels.Add(new TestModel { TestId = 2, TestAmount = 45.56m, TestDescription = "Something longer", TestName = "Test of Tests 2" });
            testModels.Add(new TestModel { TestId = 1, TestAmount = 1.0m, TestDescription = "Something long", TestName = "Test of Tests 1" });

            return Ok(testModels);
        }

        // GET: api/Test/5
        public TestModel GetPaymentRecord(int id)
        {
            // Call service that contains TestModel repository for handling all TestModel related items
            //return TestModelService.GeTestModelRecord(id);

            return new TestModel { TestId = id, TestAmount = 24.56m, TestDescription = "Something long", TestName = "Test of Tests" };
            // Simple get, just return an object.
        }

        // POST: api/Test
        
        [ValidateModel]
        // Use this to auto validate the model coming in by checking the model state. Need to add an action filter attribute to custom handle response.
        public async Task<IHttpActionResult> NewPayment([FromBody]TestModel value)
        {
            // Call service to add new testmodel
            // Leaving empty for now, would normally return http result, with any messages, or errors contained within
            return BadRequest("Maybe record already exists, or something");
        }

        [ValidateModel]
        public async Task<IHttpActionResult> NewPayments([FromBody]IEnumerable<TestModel> newPayments)
        {
            // Call service to async add new testmodels
            // Leaving empty for now, would normally return http result, with any messages, or errors contained within
            var saveCount = newPayments.Count();
            return Ok(saveCount);
        }

        [ValidateModel]
        // PUT: api/Test/5
        public void UpdatePayment(int id, [FromBody]TestModel value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
