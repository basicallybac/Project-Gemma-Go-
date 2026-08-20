using UnityEngine;

public abstract class AgentMovement : MonoBehaviour, IModule, IAfterInitModule
{
    protected Rigidbody2D _rbCompo;
    protected GroundChecker _groundChecker;
    protected ModuleOwner _owner;

    protected float _moveX;
    protected float _moveY;
    protected float _movementSpeed;
    protected virtual void FixedUpdate()
    {
        MoveAgent();
    }
    public void Initialize(ModuleOwner owner)
    { 
        _owner = owner;
        _rbCompo = owner.GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }
    public virtual void AfterInit()
    {

    }
    protected void MoveAgent()
    {
        _rbCompo.linearVelocityX = _moveX * _movementSpeed;
    }

}
