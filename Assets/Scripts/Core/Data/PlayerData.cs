using System.Collections.Generic;
using Core.Data;

public class PlayerData
{
    public static PlayerData Instance { get; } = new();

    private Dictionary<PropertyKey, Property> Data = new();
    public IEnumerable<PropertyKey> AvailableProperties => Data.Keys;

    public void RegisterData(PropertyKey key, Property data)
    {
        Data[key] = data;
    }

    public Property GetProperty(PropertyKey key)
    {
        return Data[key];
    }
}