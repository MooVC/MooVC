namespace MooVC.Syntax.CSharp.ExtensionTests;

using System.Runtime.InteropServices;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenCustomOptionsThenReceiverAndMethodsUseConfiguredFormatting()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter
                .Named("Value")
                .OfType(typeof(Uri)))
            .WithMethods(method => method
                .Named("Identity")
                .Returns(Result.Void.OfType(typeof(Uri)))
                .WithBody("return value;"));

        Type.Options options = Type.Options.Default
            .WithQualifications(qualifications => qualifications.WithFormat(Qualification.Options.Formats.Global))
            .WithSnippets(snippets => snippets.WithWhitespace("\t"));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        const string Expected = """
            extension(global::System.Uri value)
            {
            	public global::System.Uri Identity()
            	{
            		return value;
            	}
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenGenericMethodThenMethodArgumentsAndParametersAreRendered()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter
                .Named("Value")
                .OfType(typeof(string)))
            .WithMethods(method => method
                .Named(declaration => declaration
                    .Named("Convert")
                    .WithArguments(generic => generic.Named("T")))
                .Accepts(parameter => parameter
                    .Named("Fallback")
                    .OfType(Symbol.Undefined.Named("T")))
                .Returns(Result.Void.OfType(Symbol.Undefined.Named("T")))
                .WithBody("return fallback;"));

        // Act
        string representation = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(representation).Contains("public T Convert<T>(T fallback)");
    }

    [Test]
    public async Task GivenInstanceMethodThenReceiverAndMethodAreRendered()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter.Named("Value").OfType(typeof(string)))
            .WithMethods(method => method
                .Named("HasContent")
                .Returns(Result.Void.OfType(typeof(bool)))
                .WithBody("return value.Length > 0;"));

        // Act
        string representation = subject.ToSnippet(Type.Options.Default);

        // Assert
        const string Expected = """
            extension(string value)
            {
                public bool HasContent()
                {
                    return value.Length > 0;
                }
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenMultipleGenericConstraintsThenSeparateWhereClausesAreRendered()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter
                .Named("Source")
                .OfType(Symbol.Undefined
                    .Named("KeyValuePair")
                    .WithArguments(Symbol.Undefined.Named("TSource"), Symbol.Undefined.Named("TResult"))))
            .WithArguments(
                Generic.Undefined.Named("TSource").WithConstraints(Constraint.Unspecified.WithNature(Natures.Class)),
                Generic.Undefined.Named("TResult").WithConstraints(Constraint.Unspecified.WithNature(Natures.Struct)))
            .WithMethods(method => method
                .Named("Convert")
                .Returns(Result.Void.OfType(Symbol.Undefined.Named("TResult")))
                .WithBody("return default;"));

        // Act
        string representation = subject.ToSnippet(Type.Options.Default);

        // Assert
        const string Expected = """
            extension<TSource, TResult>(KeyValuePair<TSource, TResult> source)
                where TSource : class
                where TResult : struct
            {
                public TResult Convert()
                {
                    return default;
                }
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Extension subject = Extension.Undefined.Extends(parameter => parameter.OfType(typeof(string)));

        // Act
        Func<Snippet> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenReceiverAttributesAndRefModifierThenBothAreRendered()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter
                .Named("Value")
                .OfType(typeof(int))
                .AttributedWith(attribute => attribute.Named(typeof(InAttribute)))
                .WithModifier(Parameter.Modes.Ref))
            .WithMethods(method => method.Named("Increment").Returns(Result.Void).WithBody("value++;"));

        // Act
        string representation = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(representation).Contains("extension([In] ref int value)");
    }

    [Test]
    public async Task GivenStaticMethodAndUnnamedReceiverThenStaticExtensionIsRendered()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter.OfType(typeof(string)))
            .WithMethods(method => method
                .Named("CreateEmpty")
                .WithExtensibility(Modifiers.Static)
                .Returns(Result.Void.OfType(typeof(string)))
                .WithBody("return string.Empty;"));

        // Act
        string representation = subject.ToSnippet(Type.Options.Default);

        // Assert
        const string Expected = """
            extension(string)
            {
                public static string CreateEmpty()
                {
                    return string.Empty;
                }
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenUndefinedThenEmptySnippetIsReturned()
    {
        // Arrange
        Extension subject = Extension.Undefined;

        // Act
        var representation = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(representation).IsEqualTo(Snippet.Empty);
    }
}