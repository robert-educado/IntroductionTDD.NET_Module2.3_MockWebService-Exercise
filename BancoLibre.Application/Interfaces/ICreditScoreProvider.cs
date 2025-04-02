namespace BancoLibre.Application.Interfaces;

public interface ICreditScoreProvider
{
    Task<int> GetCreditScoreAsync(string socialSecurityNumber);
}