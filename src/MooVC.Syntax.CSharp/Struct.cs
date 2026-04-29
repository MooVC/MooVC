namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Syntax;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# struct declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
        public Kinds Behavior { get; internal set; } = Kinds.Default;

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
        /// Returns an enumerator that iterates through the collection of symbols.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols.</returns>
        public override IEnumerator<Qualifier> GetEnumerator()
        {
            IEnumerator<Qualifier> @base = base.GetEnumerator();

            while (@base.MoveNext())
            {
                yield return @base.Current;
            }

            foreach (Qualifier qualifier in Constructors.SelectMany(constructor => constructor)
                .Concat(Fields.SelectMany(field => field))
                .Concat(Parameters.SelectMany(parameter => parameter)))
            {
                yield return qualifier;
            }
        }

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
        protected override Snippet PerformToSnippet(Options options)
        {
            Snippet signature = GetSignature(options);

            var attributes = Attributes.ToSnippet(options);
            var constructors = Constructors.ToSnippet(options, this);
            var events = Events.ToSnippet(options);
            var fields = Fields.ToSnippet(options);
            var indexers = Indexers.ToSnippet(options);
            var operators = Operators.ToSnippet(options, this);
            var properties = Properties.ToSnippet(options);
            var methods = Methods.ToSnippet(options);
            var elements = new Snippet[] { fields, constructors, events, properties, indexers, operators, methods };
            IEnumerable<Snippet> types = Types.Select(type => type.ToSnippet(options));
            Snippet body = Snippet.Blank.Combine(options, elements.Concat(types).ToArray());

            return body
                .Block(options, signature)
                .Prepend(attributes);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            Kinds behavior = Behavior;
            var clauses = Declaration.Arguments.ToSnippet(parameter => parameter.ToSnippet(options), options);
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

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Class)} {{ {nameof(Attributes)} = {DebuggerDisplayFormatter.Format(Attributes)}, {nameof(Behavior)} = {DebuggerDisplayFormatter.Format(Behavior)}, {nameof(Constructors)} = {DebuggerDisplayFormatter.Format(Constructors)}, {nameof(Declaration)} = {DebuggerDisplayFormatter.Format(Declaration)}, {nameof(Events)} = {DebuggerDisplayFormatter.Format(Events)}, {nameof(Fields)} = {DebuggerDisplayFormatter.Format(Fields)}, {nameof(Indexers)} = {DebuggerDisplayFormatter.Format(Indexers)}, {nameof(Interfaces)} = {DebuggerDisplayFormatter.Format(Interfaces)}, {nameof(IsPartial)} = {DebuggerDisplayFormatter.Format(IsPartial)}, {nameof(IsUndefined)} = {DebuggerDisplayFormatter.Format(IsUndefined)}, {nameof(Methods)} = {DebuggerDisplayFormatter.Format(Methods)}, {nameof(Operators)} = {DebuggerDisplayFormatter.Format(Operators)}, {nameof(Parameters)} = {DebuggerDisplayFormatter.Format(Parameters)}, {nameof(Properties)} = {DebuggerDisplayFormatter.Format(Properties)}, {nameof(Scope)} = {DebuggerDisplayFormatter.Format(Scope)}, {nameof(Types)} = {DebuggerDisplayFormatter.Format(Types)} }}";
        }
    }
}