using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.AttachmentServices
{
    public class AttachmentServices : IAttachmentServices
    {
        List<string> AllowedExtentions = [".png",".jpg",".jeg"];
        const int _maxSize = 2097152;
        public string? Upload(IFormFile file, string folderName)
        {
            //1.Check Extension
            var extention =Path.GetExtension(file.FileName);
            
            //2.Check Size
            if (file.Length == 0 || file.Length > _maxSize) return null;
            //3.Get Located Folder Path


            //C:\Users\Mohamed\OneDrive\Documents\MVC\DemoSession07\Demo.PL\wwwroot\Files\Images\
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Images");

            //4.Make Attachment Name Unique-- GUID
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";
            //5.Get File Path
            var filePath=Path.Combine(folderPath, fileName);
            //6.Create File Stream To Copy File[Unmanaged]
            using FileStream fs = new FileStream(filePath, FileMode.Create);


            //7.Use Stream To Copy File
            file.CopyTo(fs);
            //8.Return FileName To Store In Database
            return fileName;




        }
        public bool Delete(string filePath)
        {
            if(!File.Exists(filePath)) return false;
            
            File.Delete(filePath); return true; 
            
        }

       
    }
}
