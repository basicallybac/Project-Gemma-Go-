using UnityEngine;

public interface IMovable
{
    void SetMoveDir(float targetX);
    void MoveAgent();
    void FlipX();
    void ToggleMove(bool val);
}
