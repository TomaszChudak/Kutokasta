using System.IO;

namespace Kutokasta.Console.IO
{
    internal interface IDirectoryInfoWrapper
    {
        FileInfo[] GetFilesFromDirectory(string directoryPath, string filePattern);
    }

    internal class DirectoryInfoWrapper : IDirectoryInfoWrapper
    {
        public FileInfo[] GetFilesFromDirectory(string directoryPath, string filePattern)
        {
            return new DirectoryInfo(directoryPath).GetFiles(filePattern);
        }
    }
}