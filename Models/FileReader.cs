using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public abstract class FileReader
    {
        protected static string _path;

        private static Dictionary<string, Type> _readers = new Dictionary<string, Type>()
        {
            {".docx", typeof(DocxReader) },
            {".txt", typeof(TxtReader) }
        };
        
        public abstract string FileFormat { get; }
        public abstract string Read();

        
        public FileReader(string path)
        {
            _path = path;
        }
        public static FileReader GetFileReader(string path)
        {
            foreach(var format in _readers.Keys)
            {
                if(path.EndsWith(format))
                {
                    var type = _readers[format];
                    var constructor = type.GetConstructor(new Type[] { typeof(string) });
                    return constructor.Invoke(new object[] { path }) as FileReader;
                }
            }
            throw new FormatException();

        }
    }
}