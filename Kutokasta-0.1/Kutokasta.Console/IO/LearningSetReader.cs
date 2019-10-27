using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Kutokasta.Console.Models;

namespace Kutokasta.Console.IO
{
    internal interface ILearningSetReader
    {
        IEnumerable<LearningSet> GetLearningSets();
    }

    internal class LearningSetReader : ILearningSetReader
    {
        private const string LearningSetFolder = "LearningSets";
        private const string LearningSetFilePattern = "*.json";

        private readonly IDirectoryInfoWrapper _directoryInfoWrapper;
        private readonly IFileWrapper _fileWrapper;
        
        public LearningSetReader(IDirectoryInfoWrapper directoryInfoWrapper, IFileWrapper fileWrapper)
        {
            _directoryInfoWrapper = directoryInfoWrapper;
            _fileWrapper = fileWrapper;
        }

        public IEnumerable<LearningSet> GetLearningSets()
        {
            var fileInfos = _directoryInfoWrapper.GetFilesFromDirectory(LearningSetFolder, LearningSetFilePattern);

            foreach (var fileInfo in fileInfos) yield return ReadFileAsLearningSet(fileInfo.FullName);
        }

        private LearningSet ReadFileAsLearningSet(string filePath)
        {
            var fileContent = _fileWrapper.ReadAllText(filePath);
            var learningSet = new LearningSet();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(fileContent)))
            {
                var ser = new DataContractJsonSerializer(learningSet.GetType());
                learningSet = ser.ReadObject(ms) as LearningSet;
            }

            return learningSet;
        }
    }
}