namespace BloodManagementApp.Models;

public class BlodTest : IBloodTest
{
    public string TestName { get; set; } = string.Empty;
    public double ResultValue { get; set; }
    public bool IsFastingRequired { get; set; }
}
