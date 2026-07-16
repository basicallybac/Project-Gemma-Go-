using UnityEngine;

public struct DamageData
{
    public float DamageAmount;
    public Vector2 HitPoint;
    public Vector2 HitNormal;
    public ModuleOwner Attacker;
    public bool IsCritical;

    public DamageData(float damageAmount, Vector2 hitPoint, Vector2 hitNormal, ModuleOwner attacker, bool isCritical)
    {
        DamageAmount = damageAmount;
        HitPoint = hitPoint;
        HitNormal = hitNormal;
        Attacker = attacker;
        IsCritical = isCritical;
    }
}
