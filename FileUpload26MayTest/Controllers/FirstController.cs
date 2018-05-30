using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload26MayTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using MimeSharp;

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
        public IActionResult FileMediaCreate(FormTable f, IList<IFormFile> FilePicture, IFormFile FileDownload)
        {
            foreach (var FilePath in FilePicture)
            {
                if (FilePath != null)
                {
                    string extention = Path.GetExtension(FilePath.FileName);
                    string filenewname = DateTime.Now.ToString("ddmmyyyyhhmmsstt") + "pfn";
                    string finalpath = "/fpicpath/" + filenewname + extention;
                    FileStream FN = new FileStream(IHEN.WebRootPath + finalpath, FileMode.Create);
                    FilePath.CopyTo(FN);
                    FN.Close();
                    f.FilePath = finalpath;
                    ViewBag.Message = "media file successful save path in online database";
                }
            }

               if (FileDownload != null)
                {
                    string extention = Path.GetExtension(FileDownload.FileName);
                    string filenewname = DateTime.Now.ToString("ddmmyyyyhhmmsstt") + "dld";
                    string finalpath ="/fpicpath/" + filenewname + extention;
                    FileStream FN = new FileStream(IHEN.WebRootPath + finalpath, FileMode.Create);
                    FileDownload.CopyTo(FN);
                    FN.Close();
                    f.FileDownload = finalpath;
                    ViewBag.Message = "media file successful save path in online database";
                }

            ORM.FormTable.Add(f);
            ORM.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult FileMediaShow()
        {
            List<FormTable> obj = ORM.FormTable.ToList<FormTable>();  
            return View(obj);
        }
        [HttpGet]
        public FileResult FileDownload(string Cv)
        {
            string  Extention = Path.GetExtension(Cv);
            Mime Omine = new Mime();
             string FileType = Omine.Lookup(Extention);
            return File(Cv, FileType);
        }
        [HttpGet]
        public FileResult FileDownloadD(string Cvv)
        {
            string  Extention = Path.GetExtension(Cvv);
            Mime Omine = new Mime();
             string FileType = Omine.Lookup(Extention);
            return File(Cvv, FileType);
        }


}

   
}