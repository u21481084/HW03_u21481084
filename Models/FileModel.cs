using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace HW03_u21481084.Models
{
    public class FileModel
    {
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string fType { get; set; }
    }
}