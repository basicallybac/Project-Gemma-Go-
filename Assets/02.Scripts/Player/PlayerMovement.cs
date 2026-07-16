using UnityEngine;

public class PlayerMovement : MonoBehaviour, IModule, IAfterInitModule
{
    [SerializeField] private float moveSpeed;

    private GroundChecker _groundChecker;
    private Rigidbody2D _rbCompo;
    private ModuleOwner _owner;
    private Player _player;
    
    public void Initialize(ModuleOwner owner)
    {
        _owner = owner;
        _rbCompo = owner.GetComponent<Rigidbody2D>();
        _player = owner.GetComponent<Player>();
    }
    public void AfterInit()
    {
        _player.PlayerInput.OnMoveKeyPressed += HandleMovement;
    }
    private void OnDestroy()
    {
        _player.PlayerInput.OnMoveKeyPressed -= HandleMovement;
    }
    private void HandleMovement(float movement)
    {
        _rbCompo.linearVelocityX = movement * moveSpeed;
    }
}
