namespace MooVC.Syntax.CSharp.ConversionTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<ConversionTypeExpectation> GivenTypeThenFlagsReflectValueData()
    {
        return
        [
            new(Conversion.Type.Explicit, "explicit", true, false),
            new(Conversion.Type.Implicit, "implicit", false, true),
        ];
    }

    [Test]
    [MethodDataSource(nameof(GivenTypeThenFlagsReflectValueData))]
    public async Task GivenTypeThenFlagsReflectValue(ConversionTypeExpectation expectation)
    {
        // Arrange
        Conversion.Type subject = expectation.OperatorType;

        // Act
        bool isExplicit = subject.IsExplicit;
        bool isImplicit = subject.IsImplicit;
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(isExplicit).IsEqualTo(expectation.IsExplicit);
        _ = await Assert.That(isImplicit).IsEqualTo(expectation.IsImplicit);
        _ = await Assert.That(representation).IsEqualTo(expectation.ExpectedString);
    }

    public sealed record ConversionTypeExpectation(
        Conversion.Type OperatorType,
        string ExpectedString,
        bool IsExplicit,
        bool IsImplicit);
}