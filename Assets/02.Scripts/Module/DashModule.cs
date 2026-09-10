using System.Collections;
using UnityEngine;

public class DashModule : MonoBehaviour, IModule
{
    private AbstractMovementModule _movement;
    private ModuleOwner _owner;
    [SerializeField] private float _dashPower;
    public void Initialize(ModuleOwner owner)
    {
        _owner = owner;
        _movement = owner.GetModule<AbstractMovementModule>();
    }
    public void Dash()
    {
        _movement.ToggleMove(false);
        _movement.RbCompo.AddForceX(_dashPower * _owner.transform.right.x, ForceMode2D.Impulse);
        if(_movement.TryGetComponent<IGroundAgent>(out IGroundAgent agent))
        {
            agent.ResetGravity();
        }
        StartCoroutine(DashActiveCoroutine());
    }
    protected virtual void OnDestroy()
    {

    }
    private IEnumerator DashActiveCoroutine()
    {
        yield return new WaitForSeconds(0.15f);
        _movement.ToggleMove(true);
    }
}
