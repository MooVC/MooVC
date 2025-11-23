namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenWithTargetIsCalled
{
    [Fact]
    public void GivenTargetThenReturnsNewInstanceWithUpdatedTarget()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create();

        // Act
        Attribute result = original.WithTarget(Attribute.Specifier.Return);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Target.ShouldBe(Attribute.Specifier.Return);
        result.Name.ShouldBe(original.Name);
        result.Arguments.ShouldBe(original.Arguments);
    }
}
