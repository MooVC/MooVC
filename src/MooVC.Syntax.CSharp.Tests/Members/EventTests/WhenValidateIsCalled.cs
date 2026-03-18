namespace MooVC.Syntax.CSharp.Members.EventTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Test]
    public void GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Event subject = Event.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Test]
    public void GivenUnnamedEventThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new Symbol { Name = EventTestsData.DefaultHandler },
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Event.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Test]
    public void GivenInvalidHandlerThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new Symbol { Name = "Invalid Handler Name" },
            Name = new Name(EventTestsData.DefaultName),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Symbol.Moniker));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Test]
    public void GivenValidEventThenNoValidationErrorsReturned()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}