using UnityEngine;

public interface IJumpableAgent
{
    float JumpPower { get; }
    bool CanJump { get; }
    void Jump();
}
