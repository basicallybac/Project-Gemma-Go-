using UnityEngine;

public struct DamageData
{
    public float DamageAmount { get; private set; }
    public Vector2 HitPoint { get; private set; }
    public Vector2 HitNormal { get; private set; }
    public ModuleOwner Attacker { get; private set; }
    public bool IgnoreResistance { get; private set; }
    public bool IsCritical { get; private set; }
    public DamageType damageType { get; private set; }

    public DamageData(float damageAmount, Vector2 hitPoint, Vector2 hitNormal, ModuleOwner attacker, bool canModified, bool isCritical, DamageType type)
    {
        DamageAmount = damageAmount;
        HitPoint = hitPoint;
        HitNormal = hitNormal;
        Attacker = attacker;
        IgnoreResistance = canModified;
        IsCritical = isCritical;
        damageType = type;
    }
}
