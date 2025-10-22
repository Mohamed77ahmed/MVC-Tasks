using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.AttachmentServices
{
    public interface IAttachmentServices
    {
        public string? Upload(IFormFile file, string folderName);
        public bool Delete(string filePath); 
    }
}
