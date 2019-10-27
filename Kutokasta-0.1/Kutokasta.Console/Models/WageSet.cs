using System;

namespace Kutokasta.Console.Models
{
    public class WageSet
    {
        public int InputWage { get; set; }
        
        public int BiasWage { get; set; }

        public override bool Equals(object other)
        {
            if (other == null) return false;
            if (object.ReferenceEquals(this, other)) return true;
            return Equals(other as WageSet);
        }

        private bool Equals(WageSet other)
        {
            if (other == null) return false;
            return this.GetHashCode() == other.GetHashCode()
                   && this.InputWage == other.InputWage
                   && this.BiasWage == other.BiasWage;
        }

        public override int GetHashCode()
        {
            return (this.InputWage * 397) ^ this.BiasWage;
        }
    }
}