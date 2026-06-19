namespace BloodManagementApp.Models;

public interface IBloodTest
{
    public string TestName { get; set; }
    public double ResultValue { get; set; }
    public bool IsFastingRequired { get; set; }
}
