using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.IO;
using Xceed.Words.NET;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        

        [HttpGet]
        public ActionResult Encoder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(string Data, string Key, string type)
        {
            try
            {
                var enc = new Encoding();
                enc.Data = Data;
                enc.Key = Key;

                ViewBag.Data = enc.Data;
                ViewBag.Key = enc.Key;

                if (type == "encode")
                {
                    ViewBag.Type = "шифрования";
                    ViewBag.Result = enc.Encode();
                }
                else
                {
                    ViewBag.Type = "дешифрования";
                    ViewBag.Result = enc.Decode();
                }

                return View();
            }
            catch(Exception ex)
            {
                ViewBag.ExMessage = ex.Message;
                return Redirect("/Home/Encoder/");
            }
            
        }

        public FilePathResult Download(string result)
        {
            string path = Server.MapPath("~/Files/result.docx");
            using (DocX doc = DocX.Create(path))
            {
                doc.InsertParagraph(result);
                doc.Save();
            }

            return File(path, "application/docx", "result.docx");
        }

        [HttpGet]
        public ActionResult ViaFile()
        {
            ViewBag.Key = "скорпион";
            return View();
        }

        [HttpPost]
        public ActionResult ViaFile(HttpPostedFileBase upload, string key, string type)
        {
            if(upload != null)
            {
                CheckPath();

                var format = upload.FileName.Split('.');
                string path = Server.MapPath($"~/Files/toWork.{format[format.Length -1]}");
                upload.SaveAs(path);

                var reader = FileReader.GetFileReader(path);
                var enc = new Encoding();

                enc.Data = reader.Read();
                enc.Key = key;

                ViewBag.Data = enc.Data;
                ViewBag.Key = key;

                if (type == "encode")
                {
                    ViewBag.Result = enc.Encode();
                }
                else
                {
                    ViewBag.Result = enc.Decode();
                }

                return View();



            }

            return RedirectToAction("ViaFile");
        }

        private void CheckPath()
        {
            var path = Server.MapPath("~/Files");

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}