namespace MooVC.Syntax.CSharp.Chaining.ParenthesesTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Chaining;

public sealed class WhenChainIsCalled
{
    [Test]
    public async Task GivenGenericMethodArgumentWhenLineIsLongThenTypeArgumentsRemainTogether()
    {
        // Arrange
        const byte maximumLineLength = 20;
        Snippet.Options.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLineLength(maximumLineLength);

        const string value = "Execute(Create<Register, Register.Result>(source), cancellationToken);";

        string[] expected =
        [
            "Execute(",
            "    Create<Register, Register.Result>(source),",
            "    cancellationToken);",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        _ = await Assert.That(string.Join(Environment.NewLine, result)).IsEqualTo(string.Join(Environment.NewLine, expected));
    }

    [Test]
    [Arguments("    ")]
    [Arguments("\t")]
    public async Task GivenGenericPrimaryConstructorWhenLineIsLongThenEachParameterIsOnNewLine(string whitespace)
    {
        // Arrange
        Snippet.Options.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithWhitespace(whitespace);

        const string value = "public sealed partial class Service(global::Mu.Communications.Mediation.IHandler<Register, Register.Result> handler, global::Mu.Auditing.IScopeManager manager, global::Mu.Communications.Tracing.IScribe scribe)";

        string[] expected =
        [
            "public sealed partial class Service(",
            whitespace + "global::Mu.Communications.Mediation.IHandler<Register, Register.Result> handler,",
            whitespace + "global::Mu.Auditing.IScopeManager manager,",
            whitespace + "global::Mu.Communications.Tracing.IScribe scribe)",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        _ = await Assert.That(string.Join(Environment.NewLine, result)).IsEqualTo(string.Join(Environment.NewLine, expected));
    }

    [Test]
    public async Task GivenMethodSignatureWhenLineIsLongThenEachParameterIsOnNewLine()
    {
        // Arrange
        Snippet.Options.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLineLength(20);

        const string value = "public Task Execute(Order order, Customer customer, DateTime timestamp, CancellationToken cancellationToken);";

        string[] expected =
        [
            "public Task Execute(",
            "    Order order,",
            "    Customer customer,",
            "    DateTime timestamp,",
            "    CancellationToken cancellationToken);",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        _ = await Assert.That(result.Length).IsEqualTo(expected.Length);
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenNestedGenericParametersWhenLineIsLongThenTypeArgumentsRemainTogether()
    {
        // Arrange
        const byte maximumLineLength = 20;
        Snippet.Options.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLineLength(maximumLineLength);

        const string value = "public void Execute(Dictionary<string, Dictionary<int, Register.Result>> handlers, CancellationToken cancellationToken);";

        string[] expected =
        [
            "public void Execute(",
            "    Dictionary<string, Dictionary<int, Register.Result>> handlers,",
            "    CancellationToken cancellationToken);",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        _ = await Assert.That(string.Join(Environment.NewLine, result)).IsEqualTo(string.Join(Environment.NewLine, expected));
    }

    [Test]
    public async Task GivenNestedMethodCallWhenLineIsLongThenOutterParenthesesIsChainedFirst()
    {
        // Arrange
        Snippet.Options.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLineLength(20);

        const string value = "await instance.Execute(order, GetCustomerById(customerId, cancellationToken), timestamp, cancellationToken);";

        string[] expected =
        [
            "await instance.Execute(",
            "    order,",
            "    GetCustomerById(customerId, cancellationToken),",
            "    timestamp,",
            "    cancellationToken);",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        _ = await Assert.That(result.Length).IsEqualTo(expected.Length);
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    [Arguments("first < second")]
    [Arguments("first > second")]
    [Arguments("first <= second")]
    [Arguments("first >= second")]
    [Arguments("first << second")]
    [Arguments("first >> second")]
    [Arguments("item => item.IsActive")]
    public async Task GivenOperatorArgumentWhenLineIsLongThenEachArgumentIsOnNewLine(string argument)
    {
        // Arrange
        const byte maximumLineLength = 20;
        Snippet.Options.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLineLength(maximumLineLength);

        string value = $"Execute({argument}, cancellationToken);";

        string[] expected =
        [
            "Execute(",
            "    " + argument + ",",
            "    cancellationToken);",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        _ = await Assert.That(string.Join(Environment.NewLine, result)).IsEqualTo(string.Join(Environment.NewLine, expected));
    }

    [Test]
    public async Task GivenSingleGenericParameterWhenLineIsLongThenLineIsUnchanged()
    {
        // Arrange
        const byte maximumLineLength = 20;
        Snippet.Options.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLineLength(maximumLineLength);

        const string value = "public sealed partial class Service(global::Mu.Communications.Mediation.IHandler<Register, Register.Result> handler)";

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        _ = await Assert.That(string.Join(Environment.NewLine, result)).IsEqualTo(value);
    }
}