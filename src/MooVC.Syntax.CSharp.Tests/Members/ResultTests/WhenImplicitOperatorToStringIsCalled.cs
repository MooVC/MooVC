namespace MooVC.Syntax.CSharp.Members.ResultTests;

using System;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Result? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenResultThenStringMatchesToString()
    {
        // Arrange
        Result subject = ResultTestsData.Create();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
