using BancoLibre.Domain.Entities;

namespace BancoLibre.Domain.Interfaces;

public interface ILoanApplicationEvaluator
{
    Task<LoanApplicationEvaluationResult> EvaluateAsync(LoanApplication loanApplication);
}