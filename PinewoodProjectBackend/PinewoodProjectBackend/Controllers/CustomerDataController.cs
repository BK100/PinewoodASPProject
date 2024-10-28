using Microsoft.AspNetCore.Mvc;
using PinewoodProjectBackend.Data;
using PinewoodProjectBackend.Models;
using System.Text.Json;

namespace PinewoodProjectBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerDataController : ControllerBase
    {
        // API Endpoints are separated by routes - additional functionality can be implemented if features relevant to the controller are required

        [HttpGet]
        [Route("/GetCustomerData")]
        // Retrieves the customer profile data from the repo and returns it
        public string GetTableData()
        {
            var resultString = JsonSerializer.Serialize(CustomerData.GetList());

            return resultString;
        }

        [HttpPost]
        [Route("/DeleteRecord")]
        // Deletes the customer profile data with the specified ID
        public void DeleteTableData([FromBody]int id)
        {
            try
            {
                CustomerData.DeleteRecord(id);
            }
            catch (Exception ex)
            {
                throw new Exception("PP001: Could not parse requested record ID.", ex);
            }
        }

        [HttpPost]
        [Route("/AddRecord")]
        // Adds a customer profile record with the specified ID
        public void AddTableData([FromBody] CustomerProfile profile)
        {
            try
            {
                CustomerData.AddRecord(profile);
            }
            catch (Exception ex)
            {
                throw new Exception("PP002: Could not create the customer profile record.", ex);
            }
        }

        [HttpPost]
        [Route("/UpdateRecord")]
        // Updates an existing record, including the existing customerID
        public void UpdateTableData([FromBody] CustomerProfile profile)
        {
            try
            {
                CustomerData.UpdateRecord(profile);
            }
            catch (Exception ex)
            {
                throw new Exception("PP003: Could not update the customer profile record.", ex);
            }
        }
    }
}
