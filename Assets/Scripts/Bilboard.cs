using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private Transform cashedCamera;
    private void Start()
    {
        cashedCamera = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(new Vector3(cashedCamera.position.x, transform.position.y, cashedCamera.position.z));
    }
}