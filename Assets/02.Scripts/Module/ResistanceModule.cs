using UnityEngine;

public class ResistanceModule : MonoBehaviour, IModule
{
    [SerializeField] private ResistanceSO _resistanceSO;
    private ResistanceData _resData;
    public void Initialize(ModuleOwner owner)
    {
        _resData = new ResistanceData(_resistanceSO.Resistances);
    }
    public float GetMultiplier(DamageType type)
    {
        ResistanceType res = _resData.ResistanceDict[type];
        switch (res)
        {
            case ResistanceType.Immune:
                return 0f;
            case ResistanceType.Ineffective:
                return 0.5f;
            case ResistanceType.Normal:
                return 1f;
            case ResistanceType.Weak:
                return 1.5f;
            case ResistanceType.Fatal:
                return 2f;
            default:
                Debug.LogWarning("Invalid Resistance!");
                return 1f;
        }
    }
}
