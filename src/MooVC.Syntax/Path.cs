namespace MooVC.Syntax
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static System.IO.Path;
    using static MooVC.Syntax.Path_Resources;

    /// <summary>
    /// Represents a syntax element path.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Path
        : IValidatableObject
    {
        /// <summary>
        /// Gets the empty instance.
        /// </summary>
        public static readonly Path Empty = string.Empty;

        /// <summary>
        /// Initializes a new instance of the Path class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Path(string value)
        {
            _value = value ?? string.Empty;
        }

        /// <summary>
        /// Gets the directory name on the Path.
        /// </summary>
        /// <value>The directory name.</value>
        public string DirectoryName => GetDirectoryName(_value);

        /// <summary>
        /// Gets the extension on the Path.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension => GetExtension(_value);

        /// <summary>
        /// Gets the file name on the Path.
        /// </summary>
        /// <value>The file name.</value>
        public string FileName => GetFileName(_value);

        /// <summary>
        /// Gets the file name without extension on the Path.
        /// </summary>
        /// <value>The file name without extension.</value>
        public string FileNameWithoutExtension => GetFileNameWithoutExtension(_value);

        /// <summary>
        /// Gets a value indicating whether the Path is empty.
        /// </summary>
        /// <value>A value indicating whether the Path is empty.</value>
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Defines the string operator for the Path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Path path)
        {
            Guard.Against.Conversion<Path, string>(path);

            return path.ToString();
        }

        /// <summary>
        /// Performs the change extension operation for the syntax element.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>The path.</returns>
        public Path ChangeExtension(string extension)
        {
            return System.IO.Path.ChangeExtension(_value, extension);
        }

        /// <summary>
        /// Returns the string representation of the Path.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value;
        }

        /// <summary>
        /// Validates the Path.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsEmpty)
            {
                yield break;
            }

            const int Unspecified = 0;

            if (string.IsNullOrWhiteSpace(_value)
             || _value.Length == Unspecified
             || _value.IndexOfAny(GetInvalidPathChars()) >= 0)
            {
                yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Path)), new[] { nameof(Path) });
                yield break;
            }

            string fileName = FileName;

            if (!string.IsNullOrEmpty(fileName) && fileName.IndexOfAny(GetInvalidFileNameChars()) >= 0)
            {
                yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Path)), new[] { nameof(Path) });
            }
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Path)} {{ " +
                $"{nameof(DirectoryName)} = {DebuggerDisplayFormatter.Format(DirectoryName)}, " +
                $"{nameof(Extension)} = {DebuggerDisplayFormatter.Format(Extension)}, " +
                $"{nameof(FileName)} = {DebuggerDisplayFormatter.Format(FileName)}, " +
                $"{nameof(FileNameWithoutExtension)} = {DebuggerDisplayFormatter.Format(FileNameWithoutExtension)}, " +
                $"{nameof(IsEmpty)} = {DebuggerDisplayFormatter.Format(IsEmpty)} }}";
        }
    }
}