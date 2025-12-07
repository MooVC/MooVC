namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Property_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Property
        : IValidatableObject
    {
        public static readonly Property Undefined = new Property();

        private const string Separator = " ";

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Methods Behaviours { get; set; } = Methods.Default;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public Result Result { get; set; } = Result.Void;

        public Scope Scope { get; set; } = Scope.Public;

        public static implicit operator string(Property property)
        {
            Guard.Against.Conversion<Property, string>(property);

            return property.ToString();
        }

        public static implicit operator Snippet(Property property)
        {
            Guard.Against.Conversion<Property, Snippet>(property);

            return Snippet.From(property);
        }

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(
                options,
                message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Property)));

            if (IsUndefined || Behaviours.IsDefault || Behaviours.Get.IsEmpty)
            {
                return string.Empty;
            }

            Snippet signature = GetSignature();
            Snippet methods = Behaviours;

            return methods
                .Block(options, signature)
                .ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Behaviours.IsDefault || Behaviours.Get.IsEmpty)
            {
                results = results.Append(new ValidationResult(
                    PropertyValidateBehavioursRequired.Format(nameof(Behaviours), nameof(Property), nameof(Methods.Get)),
                    new[] { nameof(Behaviours) }));
            }

            if (Result.IsVoid)
            {
                results = results.Append(new ValidationResult(
                    PropertyValidateResultRequired.Format(nameof(Result), nameof(Property)),
                    new[] { nameof(Result) }));
            }

            if (Name.IsUnnamed)
            {
                results = results.Append(new ValidationResult(
                    PropertyValidateNameRequired.Format(nameof(Name), nameof(Property)),
                    new[] { nameof(Name) }));
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, results, Name)
                .Results;
        }

        private Snippet GetSignature()
        {
            string name = Name.ToString(Identifier.Options.Pascal);
            string result = Result;
            string scope = Scope;
            string signature = Separator.Combine(scope, result, name);

            return Snippet.From(signature);
        }
    }
}