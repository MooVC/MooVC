namespace MooVC.Syntax.CSharp.Operators.BinaryExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Binary> binaries = isDefault
            ? default
            : ImmutableArray<Binary>.Empty;

        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        // Act
        Snippet result = binaries.ToSnippet(construct, Snippet.Options.Default);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Binary> binaries = ImmutableArray.Create(BinaryTestsData.Create());
        OperatorsTestsData.TestConstruct? construct = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = binaries.ToSnippet(construct!, Snippet.Options.Default));

        // Assert
        exception.ParamName.ShouldBe(nameof(construct));
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Binary> binaries = ImmutableArray.Create(BinaryTestsData.Create());
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = binaries.ToSnippet(construct, options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        Binary publicAdd = BinaryTestsData.Create(@operator: Binary.Type.Add, scope: Scope.Public);
        Binary publicSubtract = BinaryTestsData.Create(@operator: Binary.Type.Subtract, scope: Scope.Public);
        Binary protectedMultiply = BinaryTestsData.Create(@operator: Binary.Type.Multiply, scope: Scope.Protected);

        ImmutableArray<Binary> binaries = ImmutableArray.Create(publicSubtract, protectedMultiply, publicAdd);

        // Act
        Snippet snippet = binaries.ToSnippet(construct, options);

        // Assert
        string[] expected =
        {
            publicAdd.ToString(construct, options),
            publicSubtract.ToString(construct, options),
            protectedMultiply.ToString(construct, options),
        };

        snippet.ToString().ShouldBe(string.Join(Environment.NewLine, expected));
    }
}
