namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenForTypeIsCalled
{
    [Test]
    public async Task GivenSubjectThenReturnsNewInstanceWithUpdatedSubject()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        var replacement = new Symbol { Name = "Other" };

        // Act
        Conversion result = original.ForType(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Direction).IsEqualTo(original.Direction);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Target).IsEqualTo(replacement);
    }
}