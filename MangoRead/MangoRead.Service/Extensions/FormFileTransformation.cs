using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Service.Extensions
{
    public static class FormFileTransformation
    {
        public async static Task<byte[]> GetBytes(this IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async static Task<IFormFile> ToFormFile(this byte[] data)
        {
            string formFileName = "titlePicture";
            string formFileName2 = "titlePicture2";
            await using var memoryStream = new MemoryStream(data);

            var file = new FormFile(memoryStream, 0, data.Length, formFileName, formFileName2)
            {
                Headers = new HeaderDictionary(),
                ContentType = null,
            };

            System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
            {
                FileName = file.FileName
            };

            file.ContentDisposition = cd.ToString();

            return file;
        }

        public async static Task<Stream> ToStream(this IFormFile file)
        {
            MemoryStream memoryStream = new MemoryStream();            
            await file.CopyToAsync(memoryStream);
            return memoryStream;
        }
    }
}
