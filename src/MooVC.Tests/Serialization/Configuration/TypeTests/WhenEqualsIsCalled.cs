namespace MooVC.Serialization.Configuration.TypeTests;

public sealed class WhenEqualsIsCalled
{
    [Test]
    [Arguments("Json", "Json", true)]
    [Arguments("Json", "Newtonsoft.Json", false)]
    [Arguments("Json", "json", false)]
    public async Task GivenTwoNamesThenTheirValuesDetermineEquality(string leftName, string rightName, bool expected)
    {
        // Arrange
        Type left = leftName;
        Type right = rightName;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
        _ = await Assert.That(left == right).IsEqualTo(expected);
        _ = await Assert.That(left != right).IsEqualTo(!expected);
    }

    [Test]
    public async Task GivenEquivalentNamesThenTheHashCodesAreEqual()
    {
        // Arrange
        const string name = "Json";
        Type left = name;
        Type right = name;

        // Act
        int result = left.GetHashCode();

        // Assert
        _ = await Assert.That(result).IsEqualTo(right.GetHashCode());
    }
}