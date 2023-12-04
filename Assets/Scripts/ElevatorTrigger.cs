using System;
using System.Collections;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] private Transform elevator;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float elevatorSpeed = 10;
    [SerializeField] private float elevatorWaitTime = 3;

    private Vector3 startElevatorPosition;
    private Vector3 endElevatorPosition => endPoint.position;
    private bool isOnStartPosition = true;
    private bool isMoving;

    private void Start()
    {
        startElevatorPosition = elevator.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out BaseCharacterController character))
        {
            TriggerElevator();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out BaseCharacterController character))
        {
            TriggerElevator();
        }
    }

    private IEnumerator MoveElevator(Vector3 positionToMove)
    {
        float smallWaitTime = 0.3f;
        positionToMove = new Vector3(elevator.position.x, positionToMove.y, elevator.position.z);
        isMoving = true;

        yield return new WaitForSeconds(smallWaitTime);

        //Elevator moving
        while (!Mathf.Approximately(elevator.position.y, positionToMove.y))
        {
            elevator.position = Vector3.MoveTowards(elevator.position, positionToMove, elevatorSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        //Elevator stopped
        if (Mathf.Approximately(elevator.position.y, startElevatorPosition.y))
        {
            isOnStartPosition = true;
            isMoving = false;
        }
        else
        {
            isOnStartPosition = false;
            yield return new WaitForSeconds(elevatorWaitTime);
            isMoving = false;

            TriggerElevator();
        }
    }

    private void TriggerElevator()
    {
        if (isMoving) return;

        if (isOnStartPosition)
        {
            StartCoroutine(MoveElevator(endElevatorPosition));
        }
        else
        {
            StartCoroutine(MoveElevator(startElevatorPosition));
        }
    }

    public void MoveToStartPosition()
    {
        if (isMoving) return;
        if (isOnStartPosition) return;

        StartCoroutine(MoveElevator(startElevatorPosition));
    }
    public void MoveToEndPosition()
    {
        if (isMoving) return;
        if (!isOnStartPosition) return;

        StartCoroutine(MoveElevator(endElevatorPosition));
    }
}
