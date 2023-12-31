using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    private Dictionary<string, AIState> States { get; }
    private AIState activeState;
    public AIState ActiveState => activeState;

    public AIStateMachine()
    {
        States = new Dictionary<string, AIState>();
    }

    public void AddState(string stateId, AIState state)
    {
        States.Add(stateId, state);
    }

    public void SetActiveState(string stateId)
    {
        activeState?.Disable();
        activeState = States[stateId];
        activeState.Enable();
    }
}
