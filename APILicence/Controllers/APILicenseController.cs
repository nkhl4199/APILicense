using APILicence.Models;
using APILicence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace APILicence.Controllers
{
    [ApiController]
    [Route("/api/APILicense")]
    public class APILicenseController : ControllerBase
    {

        [HttpGet("{appID}/{startDate}/{endDate}")]
        public IActionResult GetTransaction(string appID, string startDate, string endDate)
        {
            return Ok(APILicenseService.GetTransactions(appID, startDate, endDate));
        }

        [HttpGet]
        public IActionResult GetTransaction()
        {
            return Ok(APILicenseService.GetTransactions());
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(APITransaction transaction)
        {
            await APILicenseService.AddTransaction(transaction);
            return Ok("Added");
        }
    }
}
