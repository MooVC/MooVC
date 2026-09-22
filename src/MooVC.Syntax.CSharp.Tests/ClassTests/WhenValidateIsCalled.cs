namespace MooVC.Syntax.CSharp.ClassTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenGenericExtensionContainerThenValidationErrorIsReturned()
    {
        // Arrange
        Class subject = Create().Named(declaration => declaration.WithArguments(Generic.Undefined.Named("T")));
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Class.Extensions));
    }

    [Test]
    public async Task GivenNestedExtensionContainerThenValidationErrorIsReturned()
    {
        // Arrange
        Class subject = Type.New<Class>().Named("Outer").Containing(Create());
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Class.Types));
    }

    [Test]
    public async Task GivenNonStaticExtensionContainerThenValidationErrorIsReturned()
    {
        // Arrange
        Class subject = Create().IsStatic(false);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Class.Extensions));
    }

    [Test]
    public async Task GivenValidExtensionContainerThenNoValidationErrorsAreReturned()
    {
        // Arrange
        Class subject = Create();
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, new(subject), results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    private static Class Create()
    {
        return Type
            .New<Class>()
            .Named("SampleExtensions")
            .IsStatic(true)
            .WithExtensions(extension => extension
                .Extends(parameter => parameter
                    .Named("Value")
                    .OfType(typeof(string)))
                .WithMethods(method => method
                    .Named("Perform")
                    .Returns(Result.Void)
                    .WithBody("return;")));
    }
}