namespace BancoLibre.Domain.Entities;

public enum LoanApplicationEvaluationResult
{
    // The loan meets all criteria (e.g., income, credit score,
    // debt-to-income ratio) and is greenlit.
    Approved,
    // The application doesn’t qualify—could be due to insufficient
    // income, poor credit, or other risks.
    Denied,
    // More information or review is needed (e.g., missing documents,
    // manual underwriting, or borderline cases). This keeps it open-ended
    // for scenarios where a decision isn’t immediate.
    Pending
}