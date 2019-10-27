using System.IO;

namespace Kutokasta.Console.IO
{
    internal interface IFileWrapper
    {
        string ReadAllText(string path);
    }
    
    internal class FileWrapper : IFileWrapper
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}