using System;
using UnityEngine;

[Serializable]
public struct Resistance
{
    public DamageType DamageType;
    public ResistanceType ResistanceType;
    public Resistance(DamageType dmgType, ResistanceType resType)
    {
        DamageType = dmgType;
        ResistanceType = resType;
    }
}
