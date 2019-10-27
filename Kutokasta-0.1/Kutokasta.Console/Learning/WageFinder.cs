using System.Linq;
using Kutokasta.Console.Models;

namespace Kutokasta.Console.Learning
{
    internal interface IWageFinder
    {
        WageSet GetWorkingWages(LearningSet learningSet);
    }

    internal class WageFinder : IWageFinder
    {
        private readonly IWageLimitProvider _wageLimitProvider;
        
        public WageFinder(IWageLimitProvider wageLimitProvider)
        {
            _wageLimitProvider = wageLimitProvider;
        }
        
        public WageSet GetWorkingWages(LearningSet learningSet)
        {
            var reasonableWageSets = _wageLimitProvider.GetReasonableWageSets();

            foreach (var wageSet in reasonableWageSets)
            {
                var rightAnswersCount = GetRightAnswersCount(learningSet, wageSet);
                if (rightAnswersCount == learningSet.Examples.Count())
                    return wageSet;
            }

            return null;
        }

        private int GetRightAnswersCount(LearningSet learningSet, WageSet wageSet)
        {
            var rightAnswersCount = 0;

            foreach (var example in learningSet.Examples)
            {
                var sum = GetDendritesSum(example, wageSet);
                var answer = GetNeuronAnswer(sum);
                if (CheckIfNeuronReturnRightAnswer(example.Output, answer))
                    rightAnswersCount++;
            }

            return rightAnswersCount;
        }

        private int GetDendritesSum(Example example, WageSet wageSet)
        {
            var sum = 0;
            example.Input.ForEach(input => sum += input * wageSet.InputWage);
            sum += wageSet.BiasWage;
            return sum;
        }

        private int GetNeuronAnswer(int sum)
        {
            return sum >= 0 ? 1 : 0; // Heaviside's function
        }

        private bool CheckIfNeuronReturnRightAnswer(int rightAnswer, int currentAnswer)
        {
            return rightAnswer == currentAnswer;
        }
    }
}