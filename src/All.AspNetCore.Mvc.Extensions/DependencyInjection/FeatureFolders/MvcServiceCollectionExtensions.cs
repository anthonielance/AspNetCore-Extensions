using All.AspNetCore.Mvc.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        public static IMvcBuilder AddFeatureFolders(this IMvcBuilder builder, bool SideBySide = false)
        {
            builder.AddMvcOptions(options =>
            {
                options.Conventions.Add(new FeatureConvention());
            });

            // Set View Locations
            builder.AddRazorOptions(options =>
            {
                // {0} - Action Name
                // {1} - Controller Name
                // {2} - Area Name
                // {3} - Feature Name

                if (!SideBySide)
                {
                    // Replaces view locations entirely
                    options.AreaViewLocationFormats.Clear();
                    options.ViewLocationFormats.Clear();
                }

                // Areas
                options.AreaViewLocationFormats.Add("/Areas/{2}/Features/{3}/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Features/{3}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/Shared/{0}.cshtml");

                // Normal
                options.ViewLocationFormats.Add("/Features/{3}/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/{3}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");

                options.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
            });

            return builder;
        }
    }
}
