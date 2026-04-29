namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenWithQualificationsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Type.Options();
        Qualification.Options value = Qualification.Options.Unspecified.WithFormat(Qualification.Options.Formats.Full);

        // Act
        Type.Options result = options.WithQualifications(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Qualifications).IsEqualTo(value);
        _ = await Assert.That(options.Qualifications).IsNotEqualTo(value);
    }
}