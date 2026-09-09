using UnityEngine;

public class PlayerMovementModule : AbstractMovementModule, IAfterInitModule
{
    private Player _player;
    private JumpModule _jumpModule;
    private DashModule _dashModule;

    public override void Initialize(ModuleOwner owner)
    {
        base.Initialize(owner);
        _player = owner.GetComponent<Player>();
        _jumpModule = owner.GetModule<JumpModule>();
        _dashModule = owner.GetModule<DashModule>();
    }
    public void AfterInit()
    {
        _player.PlayerInput.OnMoveKeyPressed += HandleMoveKey;
        _player.PlayerInput.OnJumpKeyPressed += HandleJumpKey;
    }
    private void OnDestroy()
    {
        _player.PlayerInput.OnMoveKeyPressed -= HandleMoveKey;
        _player.PlayerInput.OnJumpKeyPressed -= HandleJumpKey;
    }
    private void HandleMoveKey(float x) => SetMoveDir(x);
    private void HandleJumpKey() => _jumpModule.Jump();
}
