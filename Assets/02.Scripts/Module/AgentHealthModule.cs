using UnityEngine;
using UnityEngine.Events;

public class AgentHealthModule : MonoBehaviour, IModule, IDamagable
{
    public UnityEvent OnHealthChange { get; private set; }
    public UnityEvent OnDeath { get; private set; }

    private ResistanceModule _resModule;
    public float HP
    {
        get
        {
            return _currentHP;
        }
        private set
        {
            value = Mathf.Clamp(value, 0.0f, _maxHP);
            _currentHP = value;
            if (_currentHP <= 0.0f)
                OnDeath.Invoke();
            else
                OnHealthChange.Invoke();
        }
    }
    private float _maxHP;
    private float _currentHP;
    public void Initialize(ModuleOwner owner)
    {
        _resModule = owner.GetModule<ResistanceModule>();
    }
    public void ApplyDamage(DamageData damageData)
    {
        float damage = damageData.DamageAmount;
        float multiplier = 1;
        if(!damageData.IgnoreResistance)
        {
            multiplier = _resModule.GetMultiplier(damageData.damageType);
        }
        damage *= multiplier;
        HP -= damage;
    }
    public void RecoverHealth(float amount)
    {
        HP += amount;
    }
}
