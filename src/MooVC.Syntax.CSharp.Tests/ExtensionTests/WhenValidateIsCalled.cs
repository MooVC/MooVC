namespace MooVC.Syntax.CSharp.ExtensionTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenInstanceMethodWithoutReceiverNameThenValidationErrorIsReturned()
    {
        // Arrange
        Extension subject = Create().Extends(parameter => parameter.Named(Variable.Unnamed));
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Extension.Receiver));
    }

    [Test]
    [Arguments("out")]
    [Arguments("params")]
    [Arguments("this")]
    public async Task GivenInvalidReceiverModifierThenValidationErrorIsReturned(string modifier)
    {
        // Arrange
        Extension subject = Create().Extends(parameter => parameter.WithModifier(modifier));
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Extension.Receiver));
    }

    [Test]
    public async Task GivenMissingReceiverTypeThenValidationErrorIsReturned()
    {
        // Arrange
        Extension subject = Create().Extends(parameter => parameter.OfType(Symbol.Undefined));
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Type));
    }

    [Test]
    public async Task GivenReceiverDefaultThenValidationErrorIsReturned()
    {
        // Arrange
        Extension subject = Create().Extends(parameter => parameter.DefaultedTo("default"));
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Extension.Receiver));
    }

    [Test]
    public async Task GivenStaticMethodWithUnnamedReceiverThenNoValidationErrorsAreReturned()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter.OfType(typeof(string)))
            .WithMethods(method => method
                .Named("Perform")
                .Returns(Result.Void)
                .WithExtensibility(Modifiers.Static)
                .WithBody("return;"));
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUndefinedThenNoValidationErrorsAreReturned()
    {
        // Arrange
        Extension subject = Extension.Undefined;
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenValidInstanceMethodThenNoValidationErrorsAreReturned()
    {
        // Arrange
        Extension subject = Create();
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenVirtualMethodThenValidationErrorIsReturned()
    {
        // Arrange
        Extension subject = Extension.Undefined
            .Extends(parameter => parameter.Named("Value").OfType(typeof(string)))
            .WithMethods(method => method.Named("Perform").Returns(Result.Void).WithExtensibility(Modifiers.Virtual));
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Extension.Methods));
    }

    private static Extension Create()
    {
        return Extension.Undefined
            .Extends(parameter => parameter.Named("Value").OfType(typeof(string)))
            .WithMethods(method => method.Named("Perform").Returns(Result.Void).WithBody("return;"));
    }
}