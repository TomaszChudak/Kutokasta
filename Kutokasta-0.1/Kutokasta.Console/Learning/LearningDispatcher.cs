using Kutokasta.Console.IO;

namespace Kutokasta.Console.Learning
{
    internal interface ILearningDispatcher
    {
        void ProceedAllLearningSets();
    }

    internal class LearningDispatcher : ILearningDispatcher
    {
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly ILearningSetReader _learningSetReader;
        private readonly IResultDisplayer _resultDisplayer;
        private readonly IWageFinder _wageFinder;

        public LearningDispatcher(IConsoleWrapper consoleWrapper, ILearningSetReader learningSetReader, IWageFinder wageFinder,
            IResultDisplayer resultDisplayer)
        {
            _consoleWrapper = consoleWrapper;
            _learningSetReader = learningSetReader;
            _wageFinder = wageFinder;
            _resultDisplayer = resultDisplayer;
        }

        public void ProceedAllLearningSets()
        {
            var learningSets = _learningSetReader.GetLearningSets();

            foreach (var learningSet in learningSets)
            {
                var workingWages = _wageFinder.GetWorkingWages(learningSet);
                _resultDisplayer.DisplayResult(learningSet, workingWages);
            }

            _consoleWrapper.ReadKey();
        }
    }
}