using UnityEngine;
using UnityEngine.Events;

public class Agent : ModuleOwner
{
    public Rigidbody2D RbCompo { get; private set; }
    public AgentHealthModule HealthModule { get; private set; }
    public ResistanceModule ResistanceModule { get; private set; }
    protected override void InitializeModules()
    {
        base.InitializeModules();
        RbCompo = GetComponent<Rigidbody2D>();
        HealthModule = GetModule<AgentHealthModule>();
        ResistanceModule = GetModule<ResistanceModule>();
    }
}
