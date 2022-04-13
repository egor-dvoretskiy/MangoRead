using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Middlewares
{
    public class ContentFolderMiddleware
    {
        private readonly string _path;
        private RequestDelegate _next;

        public ContentFolderMiddleware(RequestDelegate next, string path)
        {
            this._next = next;
            this._path = path;
        }

        public async Task Invoke(HttpContext context)
        {
            string relativePathToContent = this._path;

            var projectPath = Directory.GetCurrentDirectory();
            var rootContentPath = string.Concat(projectPath, relativePathToContent);
            
            var typeNames = Enum.GetNames(typeof(ManuscriptType));

            foreach (var type in typeNames)
            {
                string fullPathToFolder = string.Concat(rootContentPath, type);
                _ = Directory.CreateDirectory(fullPathToFolder);
            }

            await _next.Invoke(context);
        }
    }
}
