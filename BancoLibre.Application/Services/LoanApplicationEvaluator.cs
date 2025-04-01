using BancoLibre.Domain.Entities;
using BancoLibre.UnitTests.Services;

namespace BancoLibre.Application.Services;

public class LoanApplicationEvaluator : ILoanApplicationEvaluator
{
    private readonly ICreditScoreProvider creditScoreProvider;

    public LoanApplicationEvaluator(ICreditScoreProvider creditScoreProvider)
    {
        this.creditScoreProvider = creditScoreProvider;
    }

    public async Task<LoanApplicationEvaluationResult> EvaluateAsync(LoanApplication loanApplication)
    {
        var creditScore = await creditScoreProvider.GetCreditScoreAsync(loanApplication.SocialSecurityNumber);

        if (creditScore >= 670)
        {
            return LoanApplicationEvaluationResult.Approved;
        }

        return LoanApplicationEvaluationResult.Denied;
    }
}