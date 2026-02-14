namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
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
    using static MooVC.Syntax.CSharp.Concepts.Reference_Resources;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a C# type syntax reference.
    /// </summary>
    public abstract partial class Reference
        : Type
    {
        private const string Separator = " ";
        private readonly Parameter.Options _options;
        private readonly string _type;

        private protected Reference(Parameter.Options options, string type)
        {
            _options = options;
            _type = type;
        }

        /// <summary>
        /// Gets the symbol from which the Reference derives.
        /// </summary>
        /// <value>The base type.</value>
        [Descriptor("DerivesFrom")]
        [SuppressMessage("Usage", "FLTFY03:Type does not utilize Fluentify", Justification = "The derived class will be annotated with it.")]
        public Symbol Base { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets the constructors on the Reference.
        /// </summary>
        /// <value>The constructors.</value>
        public ImmutableArray<Constructor> Constructors { get; internal set; } = ImmutableArray<Constructor>.Empty;

        /// <summary>
        /// Gets the extensibility on the Reference.
        /// </summary>
        /// <value>The extensibility.</value>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Sealed;

        /// <summary>
        /// Gets the fields on the Reference.
        /// </summary>
        /// <value>The fields.</value>
        public ImmutableArray<Field> Fields { get; internal set; } = ImmutableArray<Field>.Empty;

        /// <summary>
        /// Gets the parameters on the Reference.
        /// </summary>
        /// <value>The parameters.</value>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Validates the Reference.
        /// </summary>
        /// <remarks>Required members include: Extensibility, Constructors, Fields, Parameters.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = base.Validate(validationContext);

            if (!Extensibility.IsPermitted(Extensibility.Abstract, Extensibility.Implicit, Extensibility.Sealed))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, GetType()),
                    new[] { nameof(Extensibility) }));
            }

            return validationContext
                .IncludeIf(!Base.IsUndefined, nameof(Base), results, Base)
                .AndIf(!Constructors.IsDefaultOrEmpty, nameof(Constructors), Constructors)
                .AndIf(!Fields.IsDefaultOrEmpty, nameof(Fields), Fields)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), Parameters)
                .Results;
        }

        /// <summary>
        /// Performs the get signature operation for the C# type syntax.
        /// </summary>
        /// <param name="extensibility">The extensibility.</param>
        /// <param name="partial">The partial.</param>
        /// <param name="name">The name.</param>
        /// <param name="scope">The scope.</param>
        /// <returns>The string.</returns>
        protected virtual string GetSignature(string extensibility, string partial, string name, string scope)
        {
            return Separator.Combine(scope, extensibility, partial, _type, $"{name}");
        }

        /// <summary>
        /// Performs the perform to snippet operation for the C# type syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The snippet.</returns>
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
            Snippet body = Snippet.Blank.Combine(options, fields, constructors, events, properties, indexers, operators, methods);

            return body.Block(options, signature);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string extensibility = Extensibility;
            string name = Name;
            var parameters = Parameters.ToSnippet(_options);
            string partial = IsPartial.Partial();
            string scope = Scope;
            string signature = GetSignature(extensibility, partial, name, scope);

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