using UnityEngine;
using UnityEngine.Events;

public class Agent : ModuleOwner, IDamagable
{
    public bool IsDead { get; set; }
    public UnityEvent OnHit;
    public UnityEvent OnDeath;
    public Rigidbody2D RbCompo { get; private set; }
    public HealthModule Health { get; private set; }
    protected override void InitializeModules()
    {
        base.InitializeModules();
        RbCompo = GetComponent<Rigidbody2D>();
        Health = GetModule<HealthModule>();
    }
    public void ApplyDamage(DamageData damageData)
    {

    }
}
