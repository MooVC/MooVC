namespace MooVC.Syntax.PathTests;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using SystemPath = System.IO.Path;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenEmptyThenNoValidationErrorReturned()
    {
        // Arrange
        Path subject = Path.Empty;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenWhitespaceThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Path("   ");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Path));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidPathCharacterThenValidationErrorReturned()
    {
        // Arrange
        char invalidPathCharacter = SystemPath.GetInvalidPathChars()[0];
        string value = $"invalid{invalidPathCharacter}path";
        var subject = new Path(value);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Path));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidFileNameCharacterThenValidationErrorReturned()
    {
        // Arrange
        char invalidFileNameCharacter = SystemPath.GetInvalidFileNameChars()
            .First(character => character != SystemPath.DirectorySeparatorChar && character != SystemPath.AltDirectorySeparatorChar);
        string value = SystemPath.Combine("src", $"file{invalidFileNameCharacter}.txt");
        var subject = new Path(value);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Path));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidPathThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}