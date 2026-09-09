using UnityEngine;
using UnityEngine.Events;

public interface IDamagable
{
    public float HP { get; }
    public UnityEvent OnHealthChange { get; }
    public UnityEvent OnDeath { get; }
    void ApplyDamage(DamageData damageData);
    void RecoverHealth(float amount);
}
