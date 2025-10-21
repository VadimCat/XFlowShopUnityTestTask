using System;
using Core.Data;

namespace Location
{
    public class LocationProperty: Property
    {
        private string _value;
        public override string TextValue => _value;
        public override event Action<string> ValueChanged;

        public LocationProperty(string startLocation)
        {
            _value = startLocation;
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
            _value = value;
            ValueChanged?.Invoke(TextValue);
        }
    }
}