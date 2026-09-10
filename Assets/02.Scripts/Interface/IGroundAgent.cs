using UnityEngine;

public interface IGroundAgent
{
    GroundChecker GroundChecker { get; }
    float GravityPower { get; }
    float TimeInAir { get; }
    float GravityDelay { get; }
    void ApplyGravity();
    void ResetGravity();
}
