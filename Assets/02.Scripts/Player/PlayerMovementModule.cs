using UnityEngine;

public class PlayerMovementModule : GroundAgentMovementModule, IAfterInitModule
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
        _player.PlayerInput.OnDashKeyPressed += HandleDashKey;
    }
    private void OnDestroy()
    {
        _player.PlayerInput.OnMoveKeyPressed -= HandleMoveKey;
        _player.PlayerInput.OnJumpKeyPressed -= HandleJumpKey;
        _player.PlayerInput.OnDashKeyPressed -= HandleDashKey;
    }
    private void HandleMoveKey(float x) => SetMoveDir(x);
    private void HandleJumpKey() => _jumpModule.Jump();
    private void HandleDashKey() => _dashModule.Dash();
}
