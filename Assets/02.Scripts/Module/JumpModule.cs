using UnityEngine;

public class JumpModule : MonoBehaviour, IModule, IJumpableAgent
{
    [field: SerializeField] public float JumpPower { get; protected set; }
    public bool CanJump { get; protected set; }
    private AbstractMovementModule _movementModule;
    private Rigidbody2D _rbCompo;
    public void Initialize(ModuleOwner owner)
    {
        _movementModule = owner.GetModule<AbstractMovementModule>();
        _rbCompo = _movementModule.RbCompo;
    }
    public void Jump()
    {
        if (!_movementModule.GroundChecker.IsGround)
            return;
        _rbCompo.AddForceY(JumpPower, ForceMode2D.Impulse);
    }
}
