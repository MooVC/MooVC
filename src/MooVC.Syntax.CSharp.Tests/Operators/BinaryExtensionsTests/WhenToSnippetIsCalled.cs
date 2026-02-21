namespace MooVC.Syntax.CSharp.Operators.BinaryExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators.BinaryTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string GivenValuesThenAnOrderedSnippetIsReturnedExpected = """
        public static Value operator +(Value left, Value right)
        {
            return left + right;
        }

        public static Value operator -(Value left, Value right)
        {
            return left + right;
        }

        protected static Value operator *(Value left, Value right)
        {
            return left + right;
        }
        """;

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Binary> binaries = isDefault
            ? default
            : [];

        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        var result = binaries.ToSnippet(Snippet.Options.Default, type);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        OperatorsTestsData.TestType? type = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = binaries.ToSnippet(Snippet.Options.Default, type!));

        // Assert
        exception.ParamName.ShouldBe(nameof(type));
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = binaries.ToSnippet(options!, type));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        Binary publicAdd = BinaryTestsData.Create(@operator: Binary.Type.Add, scope: Scope.Public);
        Binary publicSubtract = BinaryTestsData.Create(@operator: Binary.Type.Subtract, scope: Scope.Public);
        Binary protectedMultiply = BinaryTestsData.Create(@operator: Binary.Type.Multiply, scope: Scope.Protected);

        ImmutableArray<Binary> binaries = [publicSubtract, protectedMultiply, publicAdd];

        // Act
        var snippet = binaries.ToSnippet(options, type);

        // Assert
        snippet.ToString().ShouldBe(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}