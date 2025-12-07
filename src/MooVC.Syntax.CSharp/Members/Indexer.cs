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
    using static MooVC.Syntax.CSharp.Members.Indexer_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Indexer
        : IValidatableObject
    {
        public static readonly Indexer Undefined = new Indexer();
        private const string Separator = " ";

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Methods Behaviours { get; set; } = Methods.Default;

        public Parameter Parameter { get; set; } = Parameter.Undefined;

        public Result Result { get; set; } = Result.Void;

        public Scope Scope { get; set; } = Scope.Public;

        public static implicit operator string(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, string>(indexer);

            return indexer.ToString();
        }

        public static implicit operator Snippet(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, Snippet>(indexer);

            return Snippet.From(indexer);
        }

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Indexer)));

            if (IsUndefined || Behaviours.IsDefault || Behaviours.Get.IsEmpty)
            {
                return string.Empty;
            }

            Snippet signature = GetSignature();
            var methods = Snippet.From(Behaviours.ToString(options));

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
                    IndexerValidateBehavioursRequired.Format(nameof(Behaviours), nameof(Indexer), nameof(Methods.Get)),
                    new[] { nameof(Behaviours) }));
            }

            if (Result.IsVoid)
            {
                results = results.Append(new ValidationResult(
                    IndexerValidateResultRequired.Format(nameof(Result), nameof(Indexer)),
                    new[] { nameof(Result) }));
            }

            return validationContext
                .Include(nameof(Parameter), _ => !Parameter.IsUndefined, results, Parameter)
                .Results;
        }

        private Snippet GetSignature()
        {
            string parameter = Parameter;
            string result = Result;
            string scope = Scope;
            string signature = Separator.Combine(scope, result, $"this[{parameter}]");

            return Snippet.From(signature);
        }
    }
}