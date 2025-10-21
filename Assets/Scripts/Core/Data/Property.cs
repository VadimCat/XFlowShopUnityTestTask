using System;

namespace Core.Data
{
    public abstract class Property
    {
        public abstract string TextValue { get; } 
        public abstract event Action<string> ValueChanged;
        private readonly PropertyKey _key;
        
        public abstract bool CanSpend(string value);
        public abstract void Spend(string value);
        public abstract void Add(string value);
    }
}