namespace BancoLibre.Application.Services;

public interface ICreditScoreProvider
{
    Task<int> GetCreditScoreAsync(string socialSecurityNumber);
}