using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public abstract class FileReader
    {
        protected static string _path;

        public abstract string FileFormat { get; }
        public abstract string Read();

        
        public FileReader(string path)
        {
            _path = path;

            
        }
        public static FileReader GetFileReader(string path)
        {
            if(path.EndsWith(".txt"))
            {
                return new TxtReader(path);
            }
            if(path.EndsWith(".docx"))
            {
                return new DocxReader(path);
            }
            else
            {
                throw new Exception("Неверный формат");
            }

        }
    }
}