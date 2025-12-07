namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedPropertyThenEmptyReturned()
    {
        // Arrange
        Property subject = Property.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenGetOnlyPropertyWhenInlineIsLambdaThenBodyIsRendered()
    {
        // Arrange
        var behaviours = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new Property.Setter { Mode = Property.Mode.ReadOnly },
        };

        Property subject = PropertyTestsData.Create(behaviours: behaviours);

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
            .WithInline(Snippet.BlockOptions.InlineStyle.Lambda));

        // Act
        string representation = subject.ToString(options);

        // Assert
        const string Expected = "public string Value => get => value;";

        representation.ShouldBe(Expected);
    }

    [Fact]
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
                set => _value = value;
            }
            """;

        representation.ShouldBe(expected);
    }
}