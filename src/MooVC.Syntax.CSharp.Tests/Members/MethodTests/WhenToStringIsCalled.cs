namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedMethodThenEmptyReturned()
    {
        // Arrange
        Method subject = Method.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenEmptyBodyThenSignatureIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData.Create();

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("public string Perform(int value);");
    }

    [Fact]
    public void GivenBodyThenBlockIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = """
            public string Perform(int value)
            {
                return value;
            }
            """;

        representation.ShouldBe(expected);
    }
}
