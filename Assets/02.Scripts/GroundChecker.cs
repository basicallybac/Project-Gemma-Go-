using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [field: SerializeField] public LayerMask WhatIsGround;
    [SerializeField] private Vector2 groundCheckerSize;
    public bool IsGround { get; private set; }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        IsGround = Physics2D.OverlapBox(transform.position, groundCheckerSize, 0, WhatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, groundCheckerSize);
    }
}
