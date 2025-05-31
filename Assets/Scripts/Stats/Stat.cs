using Unity.Mathematics;
using UnityEngine;

public enum eStatType
{
    Hungry,
    Health
}

[System.Serializable]
public class Stat
{
    private int _maxValue;
    private int _currentValue;
    public int CurrentValue => _currentValue;

    private eStatType _statType;
    public eStatType StatType => _statType;

    public Stat(int maxValue, eStatType statType)
    {
        _statType = statType;
        _maxValue = maxValue;
        _currentValue = maxValue;
    }
    
    public void AddValue(int amount)
    {
        _currentValue = math.clamp(_currentValue + amount, _currentValue, _maxValue);
    }

    public void RemoveValue(int amount)
    {
        _currentValue = math.clamp(_currentValue - amount, 0, _maxValue);
    }

    public bool IsStarving()
    {
        if (_statType == eStatType.Hungry)
        {
            if (_currentValue == 0)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool IsDead()
    {
        if (_statType == eStatType.Health)
        {
            if (_currentValue == 0)
            {
                return true;
            }
        }
        return false;
    }
}
