using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Middlewares
{
    public static class Extension
    {
        public static IApplicationBuilder SetContentFolders(this IApplicationBuilder builder, string path)
        {
            return builder.UseMiddleware<ContentFolderMiddleware>(path);
        }
    }
}
