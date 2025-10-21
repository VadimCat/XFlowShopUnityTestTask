using System;
using Core.Data;

namespace Vip
{
    public class VipProperty: Property
    {
        private uint _value;
        public override string TextValue => _value.ToString();
        public override event Action<string> ValueChanged;

        public VipProperty(int seconds)
        {
            _value = (uint)seconds;
        }

        public override bool CanSpend(string value)
        {
            return false;
        }

        public override void Spend(string value)
        {
            throw new Exception("VIP points cannot be spent.");
        }

        public override void Add(string value)
        {
            var uintValue = uint.Parse(value);
            _value += uintValue;
            ValueChanged?.Invoke(TextValue);
        }
    }
}