using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication3.Models
{
    public class TxtReader : FileReader
    {
        public override string FileFormat => ".txt";
        public TxtReader(string path) : base(path)
        {
            
        }
        public override string Read()
        {
            string res = File.ReadAllText(_path);
            if(res.Contains('�'))
            {
                return File.ReadAllText(_path, System.Text.Encoding.Default);
            }
            return res;
        }
        
    }
}