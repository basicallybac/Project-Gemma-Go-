using System.Collections.Generic;
using UnityEngine;

public class ResistanceData
{
    public Dictionary<DamageType, ResistanceType> ResistanceDict = new Dictionary<DamageType, ResistanceType>();
    public ResistanceData(Resistance[] resistances)
    {
        foreach (Resistance res in resistances)
            ResistanceDict.Add(res.DamageType, res.ResistanceType);
    }
}
