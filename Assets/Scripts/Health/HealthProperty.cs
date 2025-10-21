using System;
using Core.Data;

namespace Health
{
    public class HealthProperty: Property
    {
        private uint _value;
        public override string TextValue => _value.ToString();
        public override event Action<string> ValueChanged;

        public HealthProperty(uint startAmount)
        {
            _value = startAmount;
        }

        public override bool CanSpend(string value)
        {
            var uintValue = uint.Parse(value);
            return _value >= uintValue;
        }

        public override void Spend(string value)
        {
            var uintValue = uint.Parse(value);
            if (_value < uintValue)
                throw new Exception("Not enough health to spend.");
            _value -= uintValue;
            ValueChanged?.Invoke(TextValue);
        }

        public override void Add(string value)
        {
            var uintValue = uint.Parse(value);
            _value += uintValue;
            ValueChanged?.Invoke(TextValue);
        }
    }
}