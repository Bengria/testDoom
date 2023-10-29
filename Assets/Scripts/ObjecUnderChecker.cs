using System;
using UnityEngine;

public class ObjecUnderChecker : MonoBehaviour
{
    public GameObject ObjectUnder => objectUnder;
    public event Action<GameObject> OnSteppingNewSurfaceEvent;

    private GameObject objectUnder;
    private Transform trs;
    private RaycastHit hit;

    private void Awake()
    {
        trs = GetComponent<Transform>();
    }

    public void OnSteppingNewSurface(GameObject newSurface)
    {
        objectUnder = newSurface;
        OnSteppingNewSurfaceEvent?.Invoke(objectUnder);
    }

    void Update()
    {
        float rayHeight = trs.position.y + 0.1f;

        if (Physics.Raycast(new Vector3(trs.position.x, rayHeight, trs.position.z), Vector3.down, out hit))
        {
            if (hit.collider.gameObject != ObjectUnder)
            {
                OnSteppingNewSurface(hit.collider.gameObject);
            }
        }
    }
}