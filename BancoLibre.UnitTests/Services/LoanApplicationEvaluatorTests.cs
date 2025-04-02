using BancoLibre.Application.Interfaces;
using BancoLibre.Application.Services;
using BancoLibre.Domain.Entities;
using Moq;

namespace BancoLibre.UnitTests.Services;

public class LoanApplicationEvaluatorTests
{
    [Fact]
    public async Task Evaluate_RejectsLoanApplication_GivenLowCreditScore()
    {
        // ------------------------------------------------------
        // Arrange
        // ------------------------------------------------------

        var creditScoreProvider = new Mock<ICreditScoreProvider>();

        creditScoreProvider.Setup(m => m.GetCreditScoreAsync(It.IsAny<string>())).Returns(Task.FromResult(300));
        
        var sut = new LoanApplicationEvaluator(creditScoreProvider.Object);

        var loanApplication = new LoanApplication("19900101-2020", 30000, OccupationType.Employed);
        
        // ------------------------------------------------------
        // Act
        // ------------------------------------------------------
        var result = await sut.EvaluateAsync(loanApplication);
        
        // ------------------------------------------------------
        // Assert
        // ------------------------------------------------------

        Assert.Equal(LoanApplicationEvaluationResult.Denied, result);
    }

    [Fact]
    public async Task Evaluate_ApprovedLoanApplication_GivenHighCreditScore()
    {
        // ------------------------------------------------------
        // Arrange
        // ------------------------------------------------------

        var creditScoreProvider = new Mock<ICreditScoreProvider>();

        creditScoreProvider.Setup(m => m.GetCreditScoreAsync(It.IsAny<string>())).Returns(Task.FromResult(670));

        var sut = new LoanApplicationEvaluator(creditScoreProvider.Object);

        var loanApplication = new LoanApplication("19900101-2010", 30000, OccupationType.Employed);

        // ------------------------------------------------------
        // Act
        // ------------------------------------------------------
        var result = await sut.EvaluateAsync(loanApplication);

        // ------------------------------------------------------
        // Assert
        // ------------------------------------------------------

        Assert.Equal(LoanApplicationEvaluationResult.Approved, result);
    }
}
