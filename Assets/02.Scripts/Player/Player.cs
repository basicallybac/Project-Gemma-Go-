using UnityEngine;

public class Player : Agent
{ 
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    protected override void InitializeModules()
    {
        base.InitializeModules();
    }
}
