namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.Elements;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "T";

    [Fact]
    public void GivenDefaultsThenDeclarationIsUnspecified()
    {
        // Act
        var subject = new Declaration();

        // Assert
        subject.Name.ShouldBe(Name.Unnamed);
        subject.Parameters.ShouldBeEmpty();
        subject.IsUnspecified.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var parameter = new Parameter { Name = ParameterName };

        // Act
        var subject = new Declaration
        {
            Name = DeclarationTestsData.DefaultName,
            Parameters = [parameter],
        };

        // Assert
        subject.Name.ShouldBe(new Name(DeclarationTestsData.DefaultName));
        subject.Parameters.ShouldBe(new[] { parameter });
        subject.IsUnspecified.ShouldBeFalse();
    }
}