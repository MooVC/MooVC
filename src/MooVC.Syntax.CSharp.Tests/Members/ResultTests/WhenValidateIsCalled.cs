namespace MooVC.Syntax.CSharp.Members.ResultTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUnspecifiedResultThenNoErrorsReturned()
    {
        // Arrange
        var subject = new Result();

        // Act
        IEnumerable<ValidationResult> results = subject.Validate(new ValidationContext(subject));

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenSpecifiedResultThenValidationIsPerformed()
    {
        // Arrange
        Result subject = ResultTestsData.Create(type: typeof(int));

        // Act
        IEnumerable<ValidationResult> results = subject.Validate(new ValidationContext(subject));

        // Assert
        results.ShouldBeEmpty();
    }
}
