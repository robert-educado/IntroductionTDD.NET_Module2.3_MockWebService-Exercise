using BancoLibre.Domain.Entities;

namespace BancoLibre.UnitTests.Services;

public interface ILoanApplicationEvaluator
{
    Task<LoanApplicationEvaluationResult> EvaluateAsync(LoanApplication loanApplication);
}