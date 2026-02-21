namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenWithArgumentsIsCalled
{
    [Fact]
    public void GivenArgumentsThenReturnsNewInstanceWithUpdatedArguments()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create(arguments: new Argument
        {
            Name = new Identifier("Original"),
            Value = "alpha",
        });

        Argument[] additional = [new Argument { Name = new Identifier("Updated"), Value = "beta" }];

        // Act
        Attribute result = original.WithArguments(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Arguments.Length.ShouldBe(2);
        result.Arguments.ShouldBe(original.Arguments.Concat(additional));
        result.Name.ShouldBe(original.Name);
        result.Target.ShouldBe(original.Target);
    }
}