using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float forwardForce = 1000;
    [SerializeField] private float sideForce = 1000;
    [SerializeField] private float sensitivity = 900;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float xMouseMove = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forse = Vector3.zero;
        //float rotation = xMouseMove * sensitivity * Time.fixedDeltaTime;

        forse += transform.forward * vertical * Time.fixedDeltaTime * forwardForce;
        forse += transform.right * horizontal * Time.fixedDeltaTime * sideForce;

        rb.AddForce(forse);
        //transform.Rotate(0, rotation, 0);

        //rb.AddForce(new Vector3(horizontal * Time.fixedDeltaTime * forwardForce, 0, vertical * Time.fixedDeltaTime * sideForce));
    }
    private void LateUpdate()
    {
        float xMouseMove = Input.GetAxis("Mouse X");

        float rotation = xMouseMove * sensitivity * Time.fixedDeltaTime;

        transform.Rotate(0, rotation, 0);
    }
}
