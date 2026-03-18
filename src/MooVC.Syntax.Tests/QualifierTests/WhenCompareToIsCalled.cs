namespace MooVC.Syntax.QualifierTests;

public sealed class WhenCompareToIsCalled
{
    [Test]
    public async Task GivenUnqualifiedAndQualifiedThenUnqualifiedIsLess()
    {
        // Arrange
        Qualifier left = Qualifier.Unqualified;
        var right = new Qualifier(["MooVC", "Syntax"]);

        // Act
        int result = left.CompareTo(right);

        // Assert
        _ = await Assert.That(result).IsLessThan(0);
    }

    [Test]
    public async Task GivenSystemQualifierThenSystemComesFirst()
    {
        // Arrange
        var left = new Qualifier(["System", "Text"]);
        var right = new Qualifier(["MooVC", "Syntax"]);

        // Act
        bool result = left < right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}