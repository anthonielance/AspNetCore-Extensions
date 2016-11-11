using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class MvcApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMvcWithDefaultAreaRoute(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
