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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Direction).IsEqualTo(original.Direction);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Target).IsEqualTo(replacement);
    }
}