namespace MooVC.Syntax.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static System.IO.Path;
    using static MooVC.Syntax.Elements.Path_Resources;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Path
        : IValidatableObject
    {
        public static readonly Path Empty = string.Empty;

        public Path(string value)
        {
            _value = value ?? string.Empty;
        }

        public string DirectoryName => GetDirectoryName(_value);

        public string Extension => GetExtension(_value);

        public string FileName => GetFileName(_value);

        public string FileNameWithoutExtension => GetFileNameWithoutExtension(_value);

        public bool IsEmpty => this == Empty;

        public static implicit operator string(Path path)
        {
            Guard.Against.Conversion<Path, string>(path);

            return path.ToString();
        }

        public Path ChangeExtension(string extension)
        {
            return System.IO.Path.ChangeExtension(_value, extension);
        }

        public override string ToString()
        {
            return _value;
        }

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
    }
}