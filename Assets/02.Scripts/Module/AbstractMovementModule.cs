using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractMovementModule : MonoBehaviour, IModule, IMovable
{
    protected ModuleOwner _owner;
    protected Rigidbody2D _rbCompo;
    protected GroundChecker _groundChecker;

    protected float _moveX;
    protected float _moveY;
    [SerializeField] protected float _walkSpeed;

    public Rigidbody2D RbCompo => _rbCompo;
    public GroundChecker GroundChecker => _groundChecker;
    public bool CanMove { get; protected set; } = true;
    public virtual void Initialize(ModuleOwner owner)
    {
        _owner = owner;
        _rbCompo = owner.GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }
    protected virtual void FixedUpdate()
    {
        if (CanMove)
            MoveAgent();
        FlipX();
    }
    public virtual void MoveAgent()
    {
        _rbCompo.linearVelocityX = _moveX * _walkSpeed;
    }
    public virtual void FlipX()
    {
        if (_moveX < 0)
            _owner.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (_moveX > 0)
            _owner.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public virtual void SetMoveDir(float targetX) => _moveX = targetX;
    public virtual void ToggleMove(bool val) => CanMove = val;
}
