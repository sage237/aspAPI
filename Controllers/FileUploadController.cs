using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [Route("apis")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
       
        private static IWebHostEnvironment _webHostEnvironment;
        public FileUploadController(IWebHostEnvironment webHostEnvironment) {

            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<string> Upload([FromForm]UploadFile obj) {            

            if (obj.file.Length > 0) {
                try {

                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\")) Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");

                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + obj.id.ToString() + obj.name +'.'+ obj.file.FileName.Split('.').Last()))
                    {
                        obj.file.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Saved:" + obj.file;
                    }
                
                } catch (Exception e) {
                    return e.ToString();
                }
            
            
            }
            else return "Upload Failed";


        }

        [HttpPost]
        [Route("Personl")]
        public async Task<String> uploadPersonal([FromForm] string name) {

            return name;
        }

        [HttpGet("download")]
        public IActionResult DownloadFile()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\Intel\\source\\repos\\WebApplication3\\wwwroot\\Images\\41Test fileName.jpg");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", "your_file_name.jpg");
        }
    }
}
