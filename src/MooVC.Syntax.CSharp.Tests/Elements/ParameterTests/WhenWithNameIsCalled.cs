namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenWithNameIsCalled
{
    private const string NewName = "other";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(modifier: Parameter.Mode.In);

        // Act
        Parameter result = original.WithName(new Variable(NewName));

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(new Variable(NewName));
        result.Attributes.ShouldBe(original.Attributes);
        result.Default.ShouldBe(original.Default);
        result.Modifier.ShouldBe(original.Modifier);
        original.Name.ShouldBe(new Variable(ParameterTestsData.DefaultName));
    }
}