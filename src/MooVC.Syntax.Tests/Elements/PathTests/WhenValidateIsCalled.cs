namespace MooVC.Syntax.Elements.PathTests;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using SystemPath = System.IO.Path;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenEmptyThenNoValidationErrorReturned()
    {
        // Arrange
        Path subject = Path.Empty;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenWhitespaceThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Path("   ");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Path));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidPathCharacterThenValidationErrorReturned()
    {
        // Arrange
        char invalidPathCharacter = SystemPath.GetInvalidPathChars().First();
        string value = $"invalid{invalidPathCharacter}path";
        var subject = new Path(value);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Path));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidFileNameCharacterThenValidationErrorReturned()
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
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Path));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidPathThenNoValidationErrorReturned()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}