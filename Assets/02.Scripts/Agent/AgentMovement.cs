using UnityEngine;

public class AgentMovement : MonoBehaviour, IModule, IAfterInitModule
{
    protected Rigidbody2D _rbCompo;
    protected GroundChecker _groundChecker;
    protected ModuleOwner _owner;
    public float MoveX => _moveX;
    public bool CanMove { get; protected set; } = true;
    public Rigidbody2D RbCompo => _rbCompo;

    protected float _moveX;
    protected float _moveY;
    protected float _walkSpeed;
    protected virtual void FixedUpdate()
    {
        if (CanMove)
            MoveAgent();
        FlipX();
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
        _rbCompo.linearVelocityX = _moveX * _walkSpeed;
    }
    protected void FlipX()
    {
        if (_moveX < 0)
            _owner.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (_moveX > 0)
            _owner.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void ToggleMove(bool val) => CanMove = val;
}
