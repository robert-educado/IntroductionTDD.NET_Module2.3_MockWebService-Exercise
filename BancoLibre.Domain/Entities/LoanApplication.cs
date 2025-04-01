namespace BancoLibre.Domain.Entities;

public class LoanApplication
{
    public LoanApplication(string socialSecurityNumber, int monthlyIncome, OccupationType occupationType)
    {
        MonthlyIncome = monthlyIncome;
        OccupationType = occupationType;
        SocialSecurityNumber = socialSecurityNumber;
    }

    public int MonthlyIncome { get; set; }
    public OccupationType OccupationType { get; set; }
    public string SocialSecurityNumber { get; set; }
}


