using System.Collections.Generic;
using Kutokasta.Console.Models;

namespace Kutokasta.Console.Learning
{
    internal interface IWageLimitProvider
    {
        IEnumerable<WageSet> GetReasonableWageSets();
    }
    
    internal class WageLimitProvider : IWageLimitProvider
    {
        private const int WageLimit = 10;
        
        public IEnumerable<WageSet> GetReasonableWageSets()
        {
            var minimanWage = 0;
            var maximalWage = 0;
            
            while (maximalWage < WageLimit)
            {
                for (var inputWage = minimanWage; inputWage <= maximalWage; inputWage++)
                for (var biasWage = minimanWage; biasWage <= maximalWage; biasWage++)
                {
                    var wageSet = new WageSet {InputWage = inputWage, BiasWage = biasWage};
                    yield return wageSet;
                }

                minimanWage--;
                maximalWage++;
            }
        }
    }
}