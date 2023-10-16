using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Platform : MonoBehaviour
{
    [SerializeField] Vector3 startPositionPlatform;
    [SerializeField] Vector3 endPositionPlatform;
    [SerializeField] float speed = 10;

    bool isPositionStateOnPlatform = false;
    bool isStart = true;

    private void Start()
    {
        startPositionPlatform = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        if (isPositionStateOnPlatform)
        {
            if (isStart)
                MovingPlatform(endPositionPlatform);
            else
                MovingPlatform(startPositionPlatform);
            if (gameObject.transform.position == startPositionPlatform|| gameObject.transform.position == endPositionPlatform) isPositionStateOnPlatform=false;
            
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerController player))
        {
            player.OnMovingWithPlatform(gameObject);
            isPositionStateOnPlatform = true;
            if (gameObject.transform.position == startPositionPlatform) isStart = true;
            if (gameObject.transform.position == endPositionPlatform) isStart = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            player.OnMovingWithPlatform(null);
        }
    }
    private void MovingPlatform(Vector3 positionEnd)
    {
        transform.position = Vector3.MoveTowards(transform.position, positionEnd, speed * Time.deltaTime);   
    }
 
}
