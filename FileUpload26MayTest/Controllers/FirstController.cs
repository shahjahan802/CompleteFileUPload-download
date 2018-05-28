using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload26MayTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FileUpload26MayTest.Controllers
{
    public class FirstController : Controller
    {
        firstonlinedbContext ORM = null;
        IHostingEnvironment IHEN = null;
        public FirstController(firstonlinedbContext _ORM, IHostingEnvironment _IHEN )
        {
            ORM = _ORM;
            IHEN = _IHEN;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FileMediaCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FileMediaCreate(FormTable f , IFormFile FilePath)
        {
             if (FilePath != null)
                {
                    string extention = Path.GetExtension(FilePath.FileName);
                    string filenewname = DateTime.Now.ToString("ddmmyyyyhhmmsstt") + "pfn";
                    string finalpath = "/fpicpath/" + filenewname + extention;
                    FilePath.CopyTo(new FileStream(IHEN.WebRootPath + finalpath, FileMode.Create));
                    f.FilePath = finalpath;
                    ViewBag.Message = "media file successful save path in online database";
                }
      
                ORM.FormTable.Add(f);
            ORM.SaveChanges();
            return View();
        }

        public IActionResult FileMediaShow()
        {
            List<FormTable> ob = ORM.FormTable.ToList<FormTable>();
           
            return View(ob);
        }
       
    }

   
}