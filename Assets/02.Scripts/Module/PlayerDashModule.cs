using UnityEngine;

public class PlayerDashModule : DashModule
{
    [SerializeField] private float dashPower;
    protected Player _player;
    public override void AfterInit()
    {
        _player = _owner.GetComponent<Player>();
        _player.PlayerInput.OnDashKeyPressed += Dash;
        _dashPower = dashPower;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _player.PlayerInput.OnDashKeyPressed -= Dash;
    }
}
