using UnityEngine;

public class DemonAIController : AIController
{
    private AIStateMachine stateMachine;

    protected override void Update()
    {
        base.Update();
    }

    private void Start()
    {
        stateMachine = new AIStateMachine();

        stateMachine.AddState("Roaming", new RoamingAIState(this, stateMachine));
        stateMachine.AddState("Chasing", new ChasingAIState(this, stateMachine));
        stateMachine.SetActiveState("Roaming");
    }
}