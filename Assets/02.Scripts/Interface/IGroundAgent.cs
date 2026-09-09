using UnityEngine;

public interface IGroundAgent
{
    float GravityPower { get; }
    float TimeInAir { get; }
    float GravityDelay { get; }
    void CheckGround();
    void ApplyGravity();
    void ResetGravity();
}
