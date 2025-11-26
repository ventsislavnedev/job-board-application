using Domain.Enum;

namespace Domain.ValueObject;

public class Salary
{
    public decimal AmountMin { get; set; }
    public decimal AmountMax { get; set; }
    public SalaryType Type { get; set; }
    public string Currency { get; set; } = "EUR";
}