using UnityEngine;

public class PlayerMovement : GroundAgentMovement
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    protected Player _player;
    public override void AfterInit()
    {
        base.AfterInit();
        _player = _owner.GetComponent<Player>();
        _player.PlayerInput.OnMoveKeyPressed += HandleMovementKey;
        _player.PlayerInput.OnJumpKeyPressed += HandleJumpKey;
        _movementSpeed = moveSpeed;
        JumpPower = jumpPower;
    }
    private void OnDestroy()
    {
        _player.PlayerInput.OnMoveKeyPressed -= HandleMovementKey;
        _player.PlayerInput.OnJumpKeyPressed -= HandleJumpKey;
    }
    protected void HandleMovementKey(float movementX) => _moveX = movementX;
    protected void HandleJumpKey() => Jump();
}
