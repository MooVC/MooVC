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

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Binary> binaries = isDefault
            ? default
            : [];

        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        var result = binaries.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        OperatorsTestsData.TestType? type = default;

        // Act
        Func<Snippet> act = () => _ = binaries.ToSnippet(Snippet.Options.Default, type!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(type));
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = binaries.ToSnippet(options!, type);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Binary publicAdd = BinaryTestsData.Create(@operator: Binary.Type.Add, scope: Scope.Public);
        Binary publicSubtract = BinaryTestsData.Create(@operator: Binary.Type.Subtract, scope: Scope.Public);
        Binary protectedMultiply = BinaryTestsData.Create(@operator: Binary.Type.Multiply, scope: Scope.Protected);

        ImmutableArray<Binary> binaries = [publicSubtract, protectedMultiply, publicAdd];

        // Act
        var snippet = binaries.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}