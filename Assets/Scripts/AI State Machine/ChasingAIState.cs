using System.Collections;
using UnityEngine;

public class ChasingAIState : AIState
{
    private AIController AIController { get; }
    public ChasingAIState(AIController aiController, AIStateMachine stateMachine) : base(stateMachine)
    {
        AIController = aiController;
    }

    private IEnumerator chasingRoutine;

    public override void Enable()
    {
        Coroutines.StartCoroutine(chasingRoutine = ChasingRoutine());
    }

    public override void Disable()
    {
        Coroutines.StopCoroutine(chasingRoutine);
    }

    IEnumerator ChasingRoutine()
    {
        Vector3 targetPos = Vector3.zero;
        while (true)
        {
           if(AIController.Sense.Target != null)
            {
                targetPos = AIController.Sense.Target.transform.position;
                AIController.MoveTo(targetPos);
            }
           yield return null;
        }
    }
}
