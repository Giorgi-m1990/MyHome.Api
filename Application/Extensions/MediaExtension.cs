using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Extensions
{
    public static class MediaExtension
    {
        public static IFormFile TestBase64(this string equipmentFiles)
        {
            byte[] bytes = Convert.FromBase64String(equipmentFiles);
            MemoryStream stream = new MemoryStream(bytes);

            IFormFile file = new FormFile(stream, 0, bytes.Length, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            return file;
        }
    }
}
