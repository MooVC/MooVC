namespace MooVC.Syntax.QualifierTests;

public sealed class WhenStartsWithIsCalled
{
    [Test]
    public async Task GivenNullOtherThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier subject = "MooVC.Syntax";
        Qualifier? other = default;

        // Act
        Func<bool> action = () => subject.StartsWith(other!);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(other));
    }

    [Test]
    [Arguments("MooVC.Syntax.CSharp", "MooVC.Syntax", true)]
    [Arguments("MooVC.Syntax", "MooVC.Syntax", true)]
    [Arguments("MooVC.Syntax", "", true)]
    [Arguments("", "MooVC", false)]
    [Arguments("MooVC.Syntax", "MooVC.Syntax.CSharp", false)]
    [Arguments("MooVC.Syntax", "Mu.Syntax", false)]
    public async Task GivenQualifierThenResultIndicatesWhetherPrefixMatches(string value, string prefix, bool expected)
    {
        // Arrange
        Qualifier subject = value;
        Qualifier other = prefix;

        // Act
        bool result = subject.StartsWith(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}