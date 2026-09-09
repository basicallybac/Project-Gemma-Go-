using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResistanceSO", menuName = "Data/Resistance")]
public class ResistanceSO : ScriptableObject
{
    [field: SerializeField] public Resistance[] Resistances { get; private set; }
}
