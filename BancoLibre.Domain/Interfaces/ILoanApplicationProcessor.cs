using BancoLibre.Domain.Entities;

namespace BancoLibre.Application.Services;

public interface ILoanApplicationProcessor
{
    Task<LoanApplicationProcessResult> ProcessAsync(LoanApplication loanApplication);
}

