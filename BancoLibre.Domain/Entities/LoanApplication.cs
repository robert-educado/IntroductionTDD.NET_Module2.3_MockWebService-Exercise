namespace BancoLibre.Domain.Entities;

public class LoanApplication
{
    public LoanApplication(int monthlyIncome, OccupationType occupationType)
    {
        MonthlyIncome = monthlyIncome;
        OccupationType = occupationType;
    }

    public int MonthlyIncome { get; set; }
    public OccupationType OccupationType { get; set; }
}


