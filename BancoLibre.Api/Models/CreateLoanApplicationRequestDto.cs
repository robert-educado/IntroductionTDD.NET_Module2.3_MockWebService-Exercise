namespace BancoLibre.Api.Models;

public class CreateLoanApplicationRequestDto
{
    public int Amount { get; set; }
    public int PaybackPeriodMonths { get; set; }
    public string SocialSecurityNumber { get; set; }
    public int ResidenceType { get; set; }
    public int ResidenceCost { get; set; }
    public int EmploymentType { get; set; }
    public DateOnly EmployedSince { get; set; }
    public int Salary { get; set; }
}
