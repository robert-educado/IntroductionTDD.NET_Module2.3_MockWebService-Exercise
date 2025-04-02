using BancoLibre.Application.Services;
using BancoLibre.Domain.Entities;
using BancoLibre.Domain.Interfaces;

namespace BancoLibre.UnitTests.Services;

public class LoanApplicationProcessor : ILoanApplicationProcessor
{
    private readonly ILoanApplicationEvaluator evaluator;

    public LoanApplicationProcessor(ILoanApplicationEvaluator evaluator)
    {
        this.evaluator = evaluator;
    }

    public async Task<LoanApplicationProcessResult> ProcessAsync(LoanApplication loanApplication)
    {
        var evaluatorResult = await evaluator.EvaluateAsync(loanApplication);

        var processResult = new LoanApplicationProcessResult()
        {
            Description = evaluatorResult.ToString()
        };

        return processResult;
    }
}