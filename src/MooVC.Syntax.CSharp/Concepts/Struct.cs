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
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a C# type syntax struct.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Struct
        : Type
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Struct Undefined = new Struct();
        private const string Separator = " ";

        /// <summary>
        /// Gets the behavior on the Struct.
        /// </summary>
        /// <value>The behavior.</value>
        public Kind Behavior { get; internal set; } = Kind.Default;

        /// <summary>
        /// Gets the constructors on the Struct.
        /// </summary>
        /// <value>The constructors.</value>
        public ImmutableArray<Constructor> Constructors { get; internal set; } = ImmutableArray<Constructor>.Empty;

        /// <summary>
        /// Gets the fields on the Struct.
        /// </summary>
        /// <value>The fields.</value>
        public ImmutableArray<Field> Fields { get; internal set; } = ImmutableArray<Field>.Empty;

        /// <summary>
        /// Gets the parameters on the Struct.
        /// </summary>
        /// <value>The parameters.</value>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Struct is undefined.
        /// </summary>
        /// <value>A value indicating whether the Struct is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Validates the Struct.
        /// </summary>
        /// <remarks>Required members include: Constructors, Fields, Parameters.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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
        /// Performs the perform to snippet operation for the C# type syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The snippet.</returns>
        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            Snippet signature = GetSignature(options);

            var attributes = Attributes.ToSnippet(options);
            var constructors = Constructors.ToSnippet(options, this);
            var events = Events.ToSnippet(Event.Options.Default.WithSnippets(options));
            var fields = Fields.ToSnippet(options);
            var indexers = Indexers.ToSnippet(Indexer.Options.Default.WithSnippets(options));
            var operators = Operators.ToSnippet(options, this);
            var properties = Properties.ToSnippet(Property.Options.Default.WithSnippets(options));
            var methods = Methods.ToSnippet(Method.Options.Default.WithSnippets(options));
            Snippet body = Snippet.Blank.Combine(options, fields, constructors, events, indexers, properties, operators, methods);

            return body
                .Block(options, signature)
                .Prepend(attributes);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            Kind behavior = Behavior;
            var clauses = Declaration.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string partial = IsPartial.Partial();
            string name = Declaration;
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