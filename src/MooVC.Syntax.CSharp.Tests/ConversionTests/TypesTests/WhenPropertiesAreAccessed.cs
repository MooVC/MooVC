namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<ConversionTypeExpectation> GivenTypeThenFlagsReflectValueData()
    {
        return
        [
            new(Conversion.Types.Explicit, "explicit", true, false),
            new(Conversion.Types.Implicit, "implicit", false, true),
        ];
    }

    [Test]
    [MethodDataSource(nameof(GivenTypeThenFlagsReflectValueData))]
    public async Task GivenTypeThenFlagsReflectValue(ConversionTypeExpectation expectation)
    {
        // Arrange
        Conversion.Types subject = expectation.OperatorType;

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
        Conversion.Types OperatorType,
        string ExpectedString,
        bool IsExplicit,
        bool IsImplicit);
}