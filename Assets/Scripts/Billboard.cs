using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cashedCamera;

    private void Start()
    {
        cashedCamera = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(new Vector3(cashedCamera.position.x, transform.position.y, cashedCamera.position.z));
    }
}