namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Extension_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# class declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Fluentify]
    [Valuify]
    public sealed partial class Class
        : Reference
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Class Undefined = new Class();

        /// <summary>
        /// Initializes a new instance of the Class class.
        /// </summary>
        public Class()
            : base(Parameter.Options.Camel, "class")
        {
        }

        /// <summary>
        /// Gets the C# 14 extension blocks declared by this class.
        /// </summary>
        /// <value>The extension blocks. The class must be static, non-generic, and top-level.</value>
        public ImmutableArray<Extension> Extensions { get; internal set; } = ImmutableArray<Extension>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Class is static.
        /// </summary>
        /// <value>A value indicating whether the Class is static.</value>
        public bool IsStatic { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the Class is undefined.
        /// </summary>
        /// <value>A value indicating whether the Class is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Returns an enumerator over qualifiers referenced by the class and its extension blocks.
        /// </summary>
        /// <returns>The qualifier enumerator.</returns>
        public override IEnumerator<Qualifier> GetEnumerator()
        {
            using (IEnumerator<Qualifier> qualifiers = base.GetEnumerator())
            {
                while (qualifiers.MoveNext())
                {
                    yield return qualifiers.Current;
                }
            }

            foreach (Qualifier qualifier in Extensions.SelectMany(extension => extension))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Validates the class and its extension blocks.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IEnumerable<ValidationResult> results = base.Validate(validationContext);

            if (!Extensions.IsDefaultOrEmpty && (!IsStatic || !Declaration.Arguments.IsDefaultOrEmpty))
            {
                results = results.Append(new ValidationResult(ValidateContainerInvalid, new[] { nameof(Extensions) }));
            }

            return validationContext
                .IncludeIf(!Extensions.IsDefaultOrEmpty, nameof(Extensions), extension => !extension.IsUndefined, results, Extensions)
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
        protected override string GetSignature(string extensibility, string partial, string name, string scope)
        {
            if (IsStatic)
            {
                extensibility = "static";
            }

            return base.GetSignature(extensibility, partial, name, scope);
        }

        /// <summary>
        /// Renders extension blocks after the other class members.
        /// </summary>
        /// <param name="attributes">The class attributes.</param>
        /// <param name="body">The existing class members.</param>
        /// <param name="options">The formatting options.</param>
        /// <param name="signature">The class signature.</param>
        /// <returns>The rendered class.</returns>
        protected override Snippet Merge(Snippet attributes, Snippet body, Options options, Snippet signature)
        {
            Snippet[] members = Extensions.Select(extension => extension.ToSnippet(options)).Prepend(body).ToArray();

            return base.Merge(attributes, Snippet.Blank.Combine(options, members), options, signature);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Class)} {{ " +
                $"{nameof(Attributes)} = `{DebuggerDisplayFormatter.Format(Attributes)}`, " +
                $"{nameof(Constructors)} = `{DebuggerDisplayFormatter.Format(Constructors)}`, " +
                $"{nameof(Declaration)} = `{DebuggerDisplayFormatter.Format(Declaration)}`, " +
                $"{nameof(Events)} = `{DebuggerDisplayFormatter.Format(Events)}`, " +
                $"{nameof(Extensibility)} = `{DebuggerDisplayFormatter.Format(Extensibility)}`, " +
                $"{nameof(Extensions)} = `{DebuggerDisplayFormatter.Format(Extensions)}`, " +
                $"{nameof(Fields)} = `{DebuggerDisplayFormatter.Format(Fields)}`, " +
                $"{nameof(Indexers)} = `{DebuggerDisplayFormatter.Format(Indexers)}`, " +
                $"{nameof(Interfaces)} = `{DebuggerDisplayFormatter.Format(Interfaces)}`, " +
                $"{nameof(IsPartial)} = `{DebuggerDisplayFormatter.Format(IsPartial)}`, " +
                $"{nameof(IsStatic)} = `{DebuggerDisplayFormatter.Format(IsStatic)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Methods)} = `{DebuggerDisplayFormatter.Format(Methods)}`, " +
                $"{nameof(Operators)} = `{DebuggerDisplayFormatter.Format(Operators)}`, " +
                $"{nameof(Parameters)} = `{DebuggerDisplayFormatter.Format(Parameters)}`, " +
                $"{nameof(Properties)} = `{DebuggerDisplayFormatter.Format(Properties)}`, " +
                $"{nameof(Scope)} = `{DebuggerDisplayFormatter.Format(Scope)}`, " +
                $"{nameof(Types)} = `{DebuggerDisplayFormatter.Format(Types)}` }}";
        }
    }
}