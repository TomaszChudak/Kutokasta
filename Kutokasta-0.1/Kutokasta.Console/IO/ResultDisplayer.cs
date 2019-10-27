using System.Net.NetworkInformation;
using Kutokasta.Console.Models;

namespace Kutokasta.Console.IO
{
    internal interface IResultDisplayer
    {
        void DisplayResult(LearningSet learningSet, WageSet wageSet);
    }

    internal class ResultDisplayer : IResultDisplayer
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public ResultDisplayer(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        public void DisplayResult(LearningSet learningSet, WageSet wageSet)
        {
            _consoleWrapper.WriteLine($"Function: {learningSet.Name}");

            _consoleWrapper.WriteLine(
                wageSet != null
                    ? $"Working wages are:\r\nInput Wages:{wageSet.InputWage}\r\nBias Wage:{wageSet.BiasWage}"
                    : "No working wages have been found.");

            _consoleWrapper.WriteLine("-----------");
        }
    }
}