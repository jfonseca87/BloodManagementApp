using BloodManagementApp.Models;
using BloodManagementApp.Services;

namespace BloodManagement.Tests;

[TestClass]
public class LabReportProcessorTest
{
    // Return a list of test names that are urgent high cholesterol tests
    [TestMethod]
    public void GetUrgentHighCholesterolTests_ReturnsExpectedResults()
    {
        // Arrange
        var tests = new List<IBloodTest>
        {
            new BlodTest { TestName = "Total cholesterol", ResultValue = 250, IsFastingRequired = true },
            new BlodTest { TestName = "HDL Cholesterol", ResultValue = 60, IsFastingRequired = true },
            new BlodTest { TestName = "LDL CholeSTErol", ResultValue = 210, IsFastingRequired = true },
            new BlodTest { TestName = "Other Cholesterol", ResultValue = 350, IsFastingRequired = false },
            new BlodTest { TestName = "CholesteroL Result By Eat Fast Food", ResultValue = 201, IsFastingRequired = true },
            new BlodTest { TestName = "CholesteroL Test V2", ResultValue = 299, IsFastingRequired = true },
            new BlodTest { TestName = "Triglycerides", ResultValue = 200, IsFastingRequired = true },
            new BlodTest { TestName = "Blood Sugar", ResultValue = 100, IsFastingRequired = false },
            new BlodTest { TestName = "", ResultValue = 500, IsFastingRequired = true }
        };
        double threshold = 200;

        // Act
        var result = LabReportProcessor.GetUrgentHighCholesterolTests(tests, threshold);

        // Assert
        var expected = new List<string> 
        { 
            "CholesteroL Result By Eat Fast Food",
            "CholesteroL Test V2",
            "LDL CholeSTErol",
            "Total cholesterol"
        };
        CollectionAssert.AreEqual(expected, result.ToList()!);
    }

    // Return an empty list if there no tests provided
    [TestMethod]
    public void GetUrgentHighCholesterolTests_ReturnsEmptyList_WhenNoTestsProvided()
    {
        // Arrange
        IEnumerable<IBloodTest> tests = [];
        double threshold = 200;

        // Act
        var result = LabReportProcessor.GetUrgentHighCholesterolTests(tests, threshold);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    // Return an argument exception if the input list is null or empty
    [TestMethod]
    public void GetUrgentHighCholesterolTests_ThrowsArgumentException_WhenInputIsNull()
    {
        // Arrange
        List<IBloodTest>? tests = null;
        double threshold = 200;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => LabReportProcessor.GetUrgentHighCholesterolTests(tests!, threshold));
    }
}
