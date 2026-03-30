namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenGetAndSetThenBodyIsRendered()
    {
        // Arrange
        var behaviours = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new Property.Setter { Behaviour = Snippet.From("_value = value;") },
        };

        Property subject = PropertyTestsData.Create(behaviours: behaviours);

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = """
            public string Value
            {
                get => value;
                init => _value = value;
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenUndefinedPropertyThenEmptyReturned()
    {
        // Arrange
        Property subject = Property.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }
}