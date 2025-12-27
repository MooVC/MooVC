namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

public sealed class WhenEqualsDirectiveIsCalled
{
    private const string AlternativeAlias = "Other";
    private const string Alias = "Alias";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Directive? left = default;
        Directive? right = default;

        // Act
        bool result = left?.Equals(right) ?? (right is null);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Directive? left = default;
        Directive right = Create();

        // Act
        bool result = left?.Equals(right) ?? false;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Directive first = Create();
        Directive second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentAliasesThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(alias: AlternativeAlias);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentQualifiersThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(qualifier: new Qualifier(["MooVC", "Alternate"]));

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentStaticStatesThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(isStatic: true);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
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