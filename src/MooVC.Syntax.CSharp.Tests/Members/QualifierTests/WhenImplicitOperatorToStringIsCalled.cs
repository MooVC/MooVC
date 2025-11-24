namespace MooVC.Syntax.CSharp.Members.QualifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string First = "System";
    private const string Second = "Collections";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Qualifier? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenQualifierThenStringMatchesToString()
    {
        // Arrange
        var subject = new Qualifier
        {
            new Segment(First),
            new Segment(Second),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
