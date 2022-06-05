using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW03_u21481084.Models;
using System.IO;

namespace HW03_u21481084.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Music()
        {
            List<FileModel> ObjFiles = new List<FileModel>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Media/Music")))
            {
                FileInfo fi = new FileInfo(strfile);
                FileModel obj = new FileModel();
                obj.FileName = fi.Name;

                ObjFiles.Add(obj);
            }
            return View(ObjFiles);
        }
        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Media/Music"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public ActionResult Delete(string fileName)
        {
            string fullpath = Path.Combine(Server.MapPath("~/Media/Music"), fileName);
            FileInfo file = new FileInfo(fullpath);
            System.IO.File.Delete(fileName);
            file.Delete();
            return RedirectToAction("Music");

        }
    }
}