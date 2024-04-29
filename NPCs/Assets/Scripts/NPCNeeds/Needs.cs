using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needs
{
    public string Name {get; private set;}
    public float Value {get; private set;}
    public float Priority {get; private set;}

    public Needs(string name, float priority,)
    {
        Name = name;
        Value = 0f;
        Priority = priority;
    }


}
