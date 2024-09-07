using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public class DcumentSettings
    {
        public static string UPLoadFile(IFormFile File ,string FolderName)
        {
            var FolderPath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files",FolderName);
            var FileName = $"{Guid.NewGuid()}-{File.FileName}";
            var FilePath=Path.Combine(FolderPath,FileName);
            using var FileStream = new FileStream(FilePath, FileMode.Create);
            File.CopyTo(FileStream);
            return FileName;
        }

    }
}
