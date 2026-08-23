using UnityEngine;

public class GroundAgentMovement : AgentMovement, IJumpableAgent, IGroundAgent
{
    public GroundChecker GroundChecker { get; protected set; }
    public float JumpPower { get; protected set; }
    public float GravityPower { get; protected set; } = -30f;
    public float TimeInAir { get; protected set; } = 0;
    public float GravityDelay { get; protected set; } = 0.15f;
    public bool CanJump { get; protected set; }
    public override void AfterInit()
    {
        GroundChecker = GetComponentInChildren<GroundChecker>();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        CheckGround();
        ApplyGravity();
    }
    public void CheckGround()
    {
        if (!GroundChecker.IsGround)
        {
            TimeInAir += Time.deltaTime;
            if (TimeInAir > GravityDelay)
            {
                ApplyGravity();
            }
        }
        else
        {
            CanJump = true;
        }
    }
    public void ApplyGravity()
    {
        if (TimeInAir > GravityDelay)
            _rbCompo.AddForceY(GravityPower);
    }
    public void Jump()
    {
        if (GroundChecker.IsGround && CanJump)
        {
            ResetGravity();
            _rbCompo.AddForceY(JumpPower, ForceMode2D.Impulse);
            CanJump = false;
        }
    }
    public void ResetGravity()
    {
        _rbCompo.linearVelocityY = 0;
        TimeInAir = 0;
    }
}
