namespace MooVC.Syntax.CSharp.DefinitionExtensionsTests;

public sealed class WhenForIsCalled
{
    private const string ClassName = "Sample";

    [Test]
    public async Task GivenBuilderThenAssignsBuiltType()
    {
        // Arrange
        var subject = new Definition();

        // Act
        Definition result = subject.For<Class>(@class => @class.Named(ClassName));

        // Assert
        _ = await Assert.That(result.Type).IsTypeOf<Class>();

        var type = (Class)result.Type;

        _ = await Assert.That(type.Declaration.Name.ToString()).IsEqualTo(ClassName);
    }

    [Test]
    public async Task GivenNoBuilderThenThrowsArgumentNullException()
    {
        // Arrange
        var subject = new Definition();
        Func<Class, Class>? builder = default;

        // Act
        Func<Definition> action = () => subject.For(builder!);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(builder));
    }
}