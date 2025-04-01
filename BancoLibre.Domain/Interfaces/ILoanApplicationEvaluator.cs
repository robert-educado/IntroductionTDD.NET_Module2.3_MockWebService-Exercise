using BancoLibre.Domain.Entities;

namespace BancoLibre.UnitTests.Services;

public interface ILoanApplicationEvaluator
{
    LoanApplicationEvaluationResult Evaluate(LoanApplication loanApplication);
}