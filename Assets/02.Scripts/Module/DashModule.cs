using System.Collections;
using UnityEngine;

public class DashModule : MonoBehaviour, IModule, IAfterInitModule
{
    //protected GroundAgentMovement _movement;
    protected ModuleOwner _owner;
    protected float _dashPower = 20;
    public void Initialize(ModuleOwner owner)
    {
        _owner = owner;
        //_movement = owner.GetComponentInChildren<GroundAgentMovement>();
    }
    public void Dash()
    {
        //_movement.ToggleMove(false);
        //_movement.ResetGravity();
        //_movement.RbCompo.AddForceX(_dashPower * _owner.transform.right.x, ForceMode2D.Impulse);
        StartCoroutine(DashActiveCoroutine());
    }
    public virtual void AfterInit()
    {

    }
    protected virtual void OnDestroy()
    {

    }
    private IEnumerator DashActiveCoroutine()
    {
        yield return new WaitForSeconds(0.15f);
        //_movement.ToggleMove(true);
    }
}
