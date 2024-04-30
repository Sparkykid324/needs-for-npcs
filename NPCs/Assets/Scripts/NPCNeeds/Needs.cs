using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needs
{
    public string Name {get; private set;}
    public float CurrentValue {get; private set;}
    public float MaxValue {get; private set;}
    public float Weight {get; private set;}
    public float Value {get; private set;}
    public float Priority {get; private set;}

    public Needs(string name, float initialValue, float maxValue, float weight, float priority)
    {
        Name = name;
        CurrentValue = initialValue;
        MaxValue = maxValue;
        Value = 0f;
        Weight = weight;
        Priority = priority;
    }

    public void NeedSatisfy (float amount)
    {
        Value = Mathf.Clamp(Value - amount, 0f, 1f);
    }

    public void NeedDegrade(float amount)
    {
        Value = Mathf.Clamp(Value + amount, 0f, 1f);
    }

    public float CalculateNeed()
    {
        // Calculate the magnitude which prioritises the need
        float magnitude = Value * Weight * Priority;
        return magnitude;
    }
}
