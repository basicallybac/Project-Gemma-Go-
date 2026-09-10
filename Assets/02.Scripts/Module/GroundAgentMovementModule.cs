using UnityEngine;

public class GroundAgentMovementModule : AbstractMovementModule, IGroundAgent
{
    public float GravityPower { get; private set; } = -9.8f;
    public float TimeInAir { get; private set; } = 0f;
    public float GravityDelay { get; private set; } = 0.2f;
    public GroundChecker GroundChecker => _groundChecker;
    protected GroundChecker _groundChecker;
    public override void Initialize(ModuleOwner owner)
    {
        base.Initialize(owner);
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!_groundChecker.IsGround)
        {
            TimeInAir += Time.deltaTime;
            ApplyGravity();
        }
        else
        {
            if (TimeInAir >= GravityDelay)
                ResetGravity();
        }
    }
    public void ApplyGravity()
    {
        if (TimeInAir >= GravityDelay)
            _rbCompo.linearVelocityY += GravityPower * Time.deltaTime;
    }
    public void ResetGravity()
    {
        _rbCompo.linearVelocityY = 0f;
        TimeInAir = 0;
    }
}
