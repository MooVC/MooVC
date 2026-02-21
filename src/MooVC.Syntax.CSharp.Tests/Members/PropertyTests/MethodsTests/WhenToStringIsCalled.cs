namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenDefaultInstanceThenReturnsAutoImplementedAccessors()
    {
        // Arrange
        Property.Methods subject = Property.Methods.Default;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldContain("get");
        representation.ShouldContain("init");
    }

    [Fact]
    public void GivenReadOnlyPropertyThenOnlyGetterIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = "value;",
            Set = new Property.Setter { Mode = Property.Mode.ReadOnly },
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("value;");
    }
}