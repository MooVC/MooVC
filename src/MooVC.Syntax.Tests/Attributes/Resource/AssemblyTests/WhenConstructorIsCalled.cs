namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenAssemblyIsUndefined()
    {
        // Act
        var subject = new Assembly();

        // Assert
        subject.Alias.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var alias = AssemblyTestsData.DefaultAlias;
        var name = AssemblyTestsData.DefaultName;

        // Act
        var subject = new Assembly
        {
            Alias = alias,
            Name = name,
        };

        // Assert
        subject.Alias.ShouldBe(alias);
        subject.Name.ShouldBe(name);
        subject.IsUndefined.ShouldBeFalse();
    }
}