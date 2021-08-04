using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace StudyingMvcCore.App.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddMvc( options =>
            {
                options.Filters.Add(new ValidateAntiForgeryTokenAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddControllersWithViews();
            services.AddRazorPages();

            return services;
        }
    }
}
