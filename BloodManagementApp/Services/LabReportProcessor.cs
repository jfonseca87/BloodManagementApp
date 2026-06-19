using BloodManagementApp.Models;

namespace BloodManagementApp.Services;

public sealed class LabReportProcessor
{
    public static IReadOnlyList<string> GetUrgentHighCholesterolTests(IEnumerable<IBloodTest> tests, double threshold)
    {
        if (tests is null)
        {
            throw new ArgumentNullException(nameof(tests));
        }

        var result = tests.Where(
            t => !string.IsNullOrWhiteSpace(t.TestName) &&
                          t.TestName.Contains("Cholesterol", StringComparison.OrdinalIgnoreCase) &&
                          t.ResultValue > threshold &&
                          t.IsFastingRequired)
            .Select(t => t.TestName);

        return [.. result.OrderBy(testName => testName)];
    }
}
