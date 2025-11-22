namespace MooVC.Syntax.CSharp.Containers.DirectiveTests;

public sealed class WhenInequalityOperatorDirectiveDirectiveIsCalled
{
    private const string AlternativeAlias = "Other";
    private const string Alias = "Alias";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Directive? left = default;
        Directive? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Directive? left = default;
        Directive right = Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Directive left = Create();
        Directive? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Directive first = Create();
        Directive second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentAliasesThenReturnsTrue()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(alias: AlternativeAlias);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentQualifiersThenReturnsTrue()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(qualifier: new Qualifier(["MooVC", "Alternate"]));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentStaticStatesThenReturnsTrue()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(isStatic: true);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    private static Directive Create(
        string alias = Alias,
        Qualifier? qualifier = default,
        bool isStatic = false)
    {
        return new Directive
        {
            Alias = new Identifier(alias),
            IsStatic = isStatic,
            Qualifier = qualifier ?? new Qualifier(["MooVC", "Syntax"]),
        };
    }
}
