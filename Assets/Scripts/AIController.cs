using System;
using UnityEngine;
using UnityEngine.AI;

public enum MoveToCompletedReason
{
    Success,
    Failure,
    Aborted
}


public class AIController : BaseCharacterController
{
    private bool isMoveToCompleted = true;
    private int pathPointIndex;
    private NavMeshPath path;
    private Action<MoveToCompletedReason> moveToComleted;

    protected override void Awake()
    {
        base.Awake();

        path = new NavMeshPath();
    }

    public bool MoveTo(Vector3 targetPos, Action<MoveToCompletedReason> completed = null)
    {
        InvokeMoveToCompleted(MoveToCompletedReason.Aborted);

        moveToComleted = completed;

        bool hasPath = NavMesh.CalculatePath(transform.position, targetPos, NavMesh.AllAreas, path);

        if (hasPath)
            pathPointIndex = 1;

        isMoveToCompleted = false;

        if (!hasPath)
            InvokeMoveToCompleted(MoveToCompletedReason.Failure);

        return hasPath;
    }

    protected virtual void Update()
    {
        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            }
        }

        if (isMoveToCompleted) return;

        Vector3 targetPos = path.corners[pathPointIndex];
        Vector3 sourcePos = transform.position;

        targetPos.y = 0;
        sourcePos.y = 0;

        if (Vector3.Distance(sourcePos, targetPos) < 1)
        {
            if (pathPointIndex + 1 >= path.corners.Length)
            {
                InvokeMoveToCompleted(MoveToCompletedReason.Success);
                return;
            }

            pathPointIndex++;
            targetPos = path.corners[pathPointIndex];
            targetPos.y = 0;
        }
        Vector3 direction = (targetPos - sourcePos).normalized;

        MoveWorld(direction.x, direction.z);
    }

    private void InvokeMoveToCompleted(MoveToCompletedReason reason)
    {
        isMoveToCompleted = true;

        Action<MoveToCompletedReason> action = moveToComleted;
        moveToComleted = null;
        action?.Invoke(reason);
    }
}