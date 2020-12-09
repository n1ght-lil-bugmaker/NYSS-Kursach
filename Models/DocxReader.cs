using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xceed.Words.NET;

namespace WebApplication3.Models
{
    public class DocxReader : FileReader
    {
        public override string FileFormat => ".docx";
        public DocxReader(string path) : base(path)
        {
            
        }
        public override string Read()
        {
            string res;
            using(var doc = DocX.Load(_path))
            {
                res = doc.Text;
            }

            return res;
        }
    }
}