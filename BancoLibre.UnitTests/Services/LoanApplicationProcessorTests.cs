using BancoLibre.Application.Interfaces;
using BancoLibre.Application.Services;
using BancoLibre.Domain.Entities;
using Moq;

namespace BancoLibre.UnitTests.Services;

public class LoanApplicationProcessorTests
{
    [Fact]
    public async Task Process_RejectsLoanApplication_GivenLowCreditScore()
    {
        // ------------------------------------------------------
        // Arrange
        // ------------------------------------------------------
        var creditScoreProvider = new Mock<ICreditScoreProvider>();
        creditScoreProvider.Setup(m => m.GetCreditScoreAsync(It.IsAny<string>())).Returns(Task.FromResult(300));
        
        var loanApplicationEvaluator = new LoanApplicationEvaluator(creditScoreProvider.Object);

        var sut = new LoanApplicationProcessor(loanApplicationEvaluator);

        var loanApplication = new LoanApplication("19900101-2010", 30000, OccupationType.Employed);
        
        // ------------------------------------------------------
        // Act
        // ------------------------------------------------------
       var result = await sut.ProcessAsync(loanApplication);


        // ------------------------------------------------------
        // Assert
        // ------------------------------------------------------

        Assert.Equal("Denied", result.Description);
    }

   
}
