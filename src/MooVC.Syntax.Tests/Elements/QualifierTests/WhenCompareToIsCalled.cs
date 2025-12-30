namespace MooVC.Syntax.Elements.QualifierTests;

public sealed class WhenCompareToIsCalled
{
    [Fact]
    public void GivenUnqualifiedAndQualifiedThenUnqualifiedIsLess()
    {
        // Arrange
        Qualifier left = Qualifier.Unqualified;
        var right = new Qualifier(["MooVC", "Syntax"]);

        // Act
        int result = left.CompareTo(right);

        // Assert
        result.ShouldBeLessThan(0);
    }

    [Fact]
    public void GivenSystemQualifierThenSystemComesFirst()
    {
        // Arrange
        var left = new Qualifier(["System", "Text"]);
        var right = new Qualifier(["MooVC", "Syntax"]);

        // Act
        bool result = left < right;

        // Assert
        result.ShouldBeTrue();
    }
}