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
    GameObject playerr;

    private void Start()
    {
        startPositionPlatform = gameObject.transform.position;
    }

    void Update()
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
        if (collider.TryGetComponent(out Player player))
        {
            playerr = collider.gameObject;

            isPositionStateOnPlatform = true;
            if (gameObject.transform.position == startPositionPlatform) isStart = true;
            if (gameObject.transform.position == endPositionPlatform) isStart = false;
        }

    }
    private void MovingPlatform(Vector3 positionEnd)
    {
        Vector3 posPersY = new Vector3(0, 0, 0);
        posPersY.y = playerr.transform.position.y - transform.position.y;
        playerr.transform.position = transform.position + posPersY;

        transform.position = Vector3.MoveTowards(transform.position, positionEnd, speed * Time.deltaTime);
        
    }
}
