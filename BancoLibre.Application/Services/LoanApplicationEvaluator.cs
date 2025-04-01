using BancoLibre.Domain.Entities;
using BancoLibre.UnitTests.Services;

namespace BancoLibre.Application.Services;

public class LoanApplicationEvaluator : ILoanApplicationEvaluator
{
    public LoanApplicationEvaluationResult Evaluate(LoanApplication loanApplication)
    {
        return LoanApplicationEvaluationResult.Denied;
    }
}