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
            if (uintValue >= 1000)
                throw new Exception("Health amount percent can't be more then 100%");
            _value -= _value * uintValue;
            ValueChanged?.Invoke(TextValue);
        }

        public override void Add(string value)
        {
            var uintValue = uint.Parse(value);
            var percent = uintValue / 100f;
            _value += (uint)(_value * percent);
            ValueChanged?.Invoke(TextValue);
        }
    }
}