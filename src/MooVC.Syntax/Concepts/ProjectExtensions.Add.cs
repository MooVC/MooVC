namespace MooVC.Syntax.Concepts
{
    using Ardalis.GuardClauses;
    using MooVC.Syntax.Elements;

    public static partial class ProjectExtensions
    {
        public static Project Add(this Project project, Resource resource, Snippet resourcePath, Snippet designerPath)
        {
            return project.Add(resource, resourcePath, designerPath, Snippet.Empty);
        }

        public static Project Add(this Project project, Resource resource, Snippet resourcePath, Snippet designerPath, Snippet customToolNamespace)
        {
            _ = Guard.Against.Null(project);
            _ = Guard.Against.Null(resource);
            _ = Guard.Against.Null(resourcePath);
            _ = Guard.Against.Null(designerPath);
            _ = Guard.Against.Null(customToolNamespace);

            if (resource.IsUndefined)
            {
                return project;
            }

            var resourceFile = new Project.ResourceFile
            {
                CustomToolNamespace = customToolNamespace,
                DesignerPath = designerPath,
                Resource = resource,
                ResourcePath = resourcePath,
            };

            return project.WithResources(resourceFile);
        }
    }
}
