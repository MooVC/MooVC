namespace MooVC.Syntax.CSharp.Members.QualifierTests;

public sealed class WhenCompareToIsCalled
{
    [Fact]
    public void GivenUnqualifiedAndQualifiedThenUnqualifiedIsLess()
    {
        // Arrange
        Qualifier left = Qualifier.Unqualified;
        Qualifier right = new Qualifier(["MooVC", "Syntax"]);

        // Act
        int result = left.CompareTo(right);

        // Assert
        result.ShouldBeLessThan(0);
    }

    [Fact]
    public void GivenSystemQualifierThenSystemComesFirst()
    {
        // Arrange
        Qualifier left = new Qualifier(["System", "Text"]);
        Qualifier right = new Qualifier(["MooVC", "Syntax"]);

        // Act
        bool result = left < right;

        // Assert
        result.ShouldBeTrue();
    }
}