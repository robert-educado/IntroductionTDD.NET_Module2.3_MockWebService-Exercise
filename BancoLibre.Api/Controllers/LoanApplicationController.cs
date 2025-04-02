using BancoLibre.Api.Models;
using BancoLibre.Application.Services;
using BancoLibre.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BancoLibre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationProcessor loanApplicationProcessor;

        public LoanApplicationController(ILoanApplicationProcessor loanApplicationProcessor)
        {
            this.loanApplicationProcessor = loanApplicationProcessor;
        }

        // POST /api/loanapplication
        [HttpPost]
        public async Task<ActionResult> Create(CreateLoanApplicationRequestDto request)
        {
            // TODO: Utvärdera låneansökan

            var loanApplication = new LoanApplication(
                monthlyIncome: request.Salary,
                occupationType: (OccupationType)request.EmploymentType,
                socialSecurityNumber: request.SocialSecurityNumber);

            var loanApplicationProcessorResult = await loanApplicationProcessor.ProcessAsync(loanApplication);

            var response = new CreateLoanApplicationResponseDto();

            // Returnera 201 Create för att indikera att låneansökan
            // har skapats.
            return Created("", response);
        }
    }
}
