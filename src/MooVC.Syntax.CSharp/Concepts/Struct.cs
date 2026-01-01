namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.CSharp.Syntax;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a c# type syntax struct.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Struct
        : Type
    {
        /// <summary>
        /// Gets the undefined on the Struct.
        /// </summary>
        public static readonly Struct Undefined = new Struct();
        private const string Separator = " ";

        /// <summary>
        /// Gets or sets the behavior on the Struct.
        /// </summary>
        public Kind Behavior { get; internal set; } = Kind.Default;

        /// <summary>
        /// Gets or sets the constructors on the Struct.
        /// </summary>
        public ImmutableArray<Constructor> Constructors { get; internal set; } = ImmutableArray<Constructor>.Empty;

        /// <summary>
        /// Gets or sets the fields on the Struct.
        /// </summary>
        public ImmutableArray<Field> Fields { get; internal set; } = ImmutableArray<Field>.Empty;

        /// <summary>
        /// Gets or sets the parameters on the Struct.
        /// </summary>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Struct is undefined.
        /// </summary>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Validates the Struct and returns validation results.
        /// </summary>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = base.Validate(validationContext);

            return validationContext
                .IncludeIf(!Constructors.IsDefaultOrEmpty, nameof(Constructors), results, Constructors)
                .AndIf(!Fields.IsDefaultOrEmpty, nameof(Fields), Fields)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), Parameters)
                .Results;
        }

        /// <summary>
        /// Performs the Perform To Snippet operation for the c# type syntax.
        /// </summary>
        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            Snippet signature = GetSignature(options);

            var constructors = Constructors.ToSnippet(options, this);
            var events = Events.ToSnippet(options);
            var fields = Fields.ToSnippet(options);
            var indexers = Indexers.ToSnippet(options);
            var operators = Operators.ToSnippet(options, this);
            var properties = Properties.ToSnippet(options);
            var methods = Methods.ToSnippet(options);
            Snippet body = Snippet.Blank.Combine(options, fields, constructors, events, indexers, properties, operators, methods);

            return body.Block(options, signature);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            Kind behavior = Behavior;
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string partial = IsPartial.Partial();
            string name = Name;
            var parameters = Parameters.ToSnippet(Parameter.Options.Pascal);
            string scope = Scope;
            string signature = Separator.Combine(scope, behavior, partial, "struct", $"{name}");

            if (!parameters.IsEmpty)
            {
                signature = $"{signature}({parameters})";
            }

            if (!clauses.IsEmpty)
            {
                return clauses
                    .Shift(options)
                    .Prepend(options, Environment.NewLine)
                    .Prepend(options, signature);
            }

            return Snippet.From(options, signature);
        }
    }
}