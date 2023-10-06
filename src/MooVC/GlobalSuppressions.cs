using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Design",
    "CA1005:Avoid excessive parameters on generic types",
    Justification = "The problem the class solves precludes any reduction in the number of generic parameters.",
    Scope = "type",
    Target = "~T:MooVC.Persistence.MappedStore`3")]