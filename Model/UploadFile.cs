using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Model
{
    public class UploadFile
    {
        public int id { get; set; }
        public string name { get; set; }
        public IFormFile file { get; set; }

    }
}
