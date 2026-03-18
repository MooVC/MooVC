namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenUndefinedPropertyThenEmptyReturned()
    {
        // Arrange
        Property subject = Property.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenGetAndSetThenBodyIsRendered()
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

        representation.ShouldBe(expected);
    }
}