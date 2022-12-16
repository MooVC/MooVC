using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Style",
    "IDE0046:Convert to conditional expression",
    Justification = "The suggested approach is less readable.",
    Scope = "member",
    Target = "~M:MooVC.Collections.Generic.EnumerableExtensions.IndexOf``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.Boolean})~System.Int32")]

[assembly: SuppressMessage(
    "Design",
    "CA1005:Avoid excessive parameters on generic types",
    Justification = "The problem the class solves precludes any reduction in the number of generic parameters.",
    Scope = "type",
    Target = "~T:MooVC.Persistence.MappedStore`3")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1600:Elements should be documented",
    Justification = "Obsolete feature, slated for removal in v8 - Not worth documentating.",
    Scope = "type",
    Target = "~T:MooVC.Serialization.SerializationInfoExtensions")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1601:Partial elements should be documented",
    Justification = "Obsolete feature, slated for removal in v8 - Not worth documentating.",
    Scope = "type",
    Target = "~T:MooVC.Serialization.SerializationInfoExtensions")]