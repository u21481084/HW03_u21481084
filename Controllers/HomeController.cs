using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW03_u21481084.Models;
using System.IO;

namespace HW03_u21481084.Controllers
{
    public class HomeController : Controller
    {
        public string FileRadio;
       
        public ActionResult Index()
        {
          

            return View();
        }
       public string GetFileType (FormCollection frm)
        {
            FileRadio = frm["FileType"].ToString();
            return FileRadio;
        }
        

    public ActionResult About()
        {
            ViewBag.Message = "Some stuff about me";

            return View();
        }

        public ActionResult FileUpload(FormCollection frm)
        {
            FileRadio = frm["FileType"].ToString();
            List<FileModel> ObjFiles = new List<FileModel>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Media/"+FileRadio)))
            {
                FileInfo fi = new FileInfo(strfile);
                FileModel obj = new FileModel();
                obj.FileName = fi.Name;

                ObjFiles.Add(obj);
            }


            return View(ObjFiles);
        }


        [HttpPost]
        public ActionResult FileUpload(FileModel doc, FormCollection frm)
        {
            FileRadio = frm["FileType"].ToString();
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Media/"+FileRadio), fileName);
                    file.SaveAs(filePath);
                }
            }
            TempData["Message"] = "files uploaded successfully";
            return RedirectToAction("Index");
        }



    }
}