////namespace Mu.Modelling.Components.Domain;

////extern alias Framework;

////using Graphify;
////using MooVC.Modelling;
////using MooVC.Syntax.CSharp;
////using MooVC.Syntax.CSharp.Elements;
////using MooVC.Syntax.CSharp.Members;
////using Builder = MooVC.Syntax.Builder;
////using Template = MooVC.Syntax.Concepts.Project;
////using MooVC.Syntax.Concepts;
////using MooVC.Syntax.Attributes.Project;

////internal sealed class Project
////    : IVisitor<Model.Graph.Areas.Area.Units.Unit, File>
////{
////    public IAsyncEnumerable<File> Observe(Model.Graph.Areas.Area.Units.Unit unit, CancellationToken cancellationToken)
////    {
////        var content = Builder
////            .New<Template>()
////            .WithPropertyGroups(group => group.WithProperties());

////        yield return new File(content, Extensions.Code, unit.Value.Name, $"src/{unit.ProjectName}/");
////    }
////}