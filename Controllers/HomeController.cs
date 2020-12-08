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
        public ActionResult Result(Encoding enc, string type)
        {
            try
            {
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
            var path = Server.MapPath("~/Files/result.docx");


            using (var doc = DocX.Create(path))
            {
                doc.InsertParagraph(result);
                doc.Save();
            }

            return File(path, "application/docx", "result.docx");
        }

        [HttpGet]
        public ActionResult ViaFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadResult(HttpPostedFileBase upload, string key, string type)
        {
            if(upload != null)
            {
                try
                {
                    if(!upload.FileName.EndsWith(".docx"))
                    {
                        return RedirectToAction("ViaFile");
                    }
                    var path = Server.MapPath("~/Files/toWork.docx");
                    upload.SaveAs(path);
                    var enc = new Encoding();

                    using (var doc = DocX.Load(path))
                    {
                        enc.Data = doc.Text;
                    }
                    enc.Key = key;

                    ViewBag.Data = enc.Data;
                    ViewBag.Key = key;

                    if(type == "encode")
                    {
                        ViewBag.Type = "шифрования";
                        ViewBag.Result = enc.Encode();
                        return Download(enc.Encode());
                    }
                    else
                    {
                        ViewBag.Type = "дешифрования";
                        ViewBag.Result = enc.Decode();
                        return Download(enc.Decode());
                    }

                }
                catch
                {
                    return RedirectToAction("ViaFile");
                }
            }

            return RedirectToAction("ViaFile");
        }
    }
}