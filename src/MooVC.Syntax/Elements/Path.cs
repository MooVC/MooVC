namespace MooVC.Syntax.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.Elements.Path_Resources;
    using IOPath = System.IO.Path;
    using Ignore = Valuify.IgnoreAttribute;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Path
        : IValidatableObject
    {
        public static readonly Path Empty = string.Empty;

        public string DirectoryName => IOPath.GetDirectoryName(_value);

        public string Extension => IOPath.GetExtension(_value);

        public string FileName => IOPath.GetFileName(_value);

        public string FileNameWithoutExtension => IOPath.GetFileNameWithoutExtension(_value);

        [Ignore]
        public bool IsEmpty => this == Empty;

        public static implicit operator string(Path path)
        {
            Guard.Against.Conversion<Path, string>(path);

            return path.ToString();
        }

        public Path ChangeExtension(string extension)
        {
            return IOPath.ChangeExtension(_value, extension) ?? string.Empty;
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
                || _value.IndexOfAny(IOPath.GetInvalidPathChars()) >= 0)
            {
                yield return new ValidationResult(
                    ValidateValueRequired.Format(_value, nameof(Path)),
                    new[] { nameof(Path) });
                yield break;
            }

            string fileName = FileName;

            if (!string.IsNullOrEmpty(fileName) && fileName.IndexOfAny(IOPath.GetInvalidFileNameChars()) >= 0)
            {
                yield return new ValidationResult(
                    ValidateValueRequired.Format(_value, nameof(Path)),
                    new[] { nameof(Path) });
            }
        }
    }
}