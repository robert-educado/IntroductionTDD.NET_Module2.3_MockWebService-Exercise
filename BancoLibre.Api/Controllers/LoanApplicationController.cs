using BancoLibre.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancoLibre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        // POST /api/loanapplication
        [HttpPost]
        public ActionResult Create(CreateLoanApplicationRequestDto request)
        {
            // TODO: Utvärdera låneansökan

            var response = new CreateLoanApplicationResponseDto();

            // Returnera 201 Create för att indikera att låneansökan
            // har skapats.
            return Created("", response);
        }
    }
}
