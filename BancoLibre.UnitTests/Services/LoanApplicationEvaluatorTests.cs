using BancoLibre.Application.Services;
using BancoLibre.Domain.Entities;

namespace BancoLibre.UnitTests.Services;

public class LoanApplicationEvaluatorTests
{
    [Fact]
    public void Evaluate_RejectsLoanApplication_GivenLowCreditScore()
    {
        // ------------------------------------------------------
        // Arrange
        // ------------------------------------------------------

        var creditScoreProvider = new CreditScoreProvider("https://localhost:8000");
        
        var sut = new LoanApplicationEvaluator(creditScoreProvider);

        var loanApplication = new LoanApplication("19900101-2010", 30000, OccupationType.Employed);
        
        // ------------------------------------------------------
        // Act
        // ------------------------------------------------------
        var result = sut.EvaluateAsync(loanApplication);
        
        // ------------------------------------------------------
        // Assert
        // ------------------------------------------------------

        Assert.Equal(LoanApplicationEvaluationResult.Denied, result);
    }

    [Fact]
    public void Evaluate_ApprovedLoanApplication_GivenHighCreditScore()
    {
        // ------------------------------------------------------
        // Arrange
        // ------------------------------------------------------

        var creditScoreProvider = new CreditScoreProvider("https://localhost:8000");

        var sut = new LoanApplicationEvaluator(creditScoreProvider);

        var loanApplication = new LoanApplication("19900101-2010", 30000, OccupationType.Employed);

        // ------------------------------------------------------
        // Act
        // ------------------------------------------------------
        var result = sut.Evaluate(loanApplication);

        // ------------------------------------------------------
        // Assert
        // ------------------------------------------------------

        Assert.Equal(LoanApplicationEvaluationResult.Approved, result);
    }
}
