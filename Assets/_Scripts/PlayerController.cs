using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardForce = 1;
    [SerializeField] private float sideForce = 1;
    [SerializeField] private float sensitivity = 1;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float xMouseMovement = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 force = Vector3.zero;
        
        force += transform.forward  * vertical * Time.fixedDeltaTime * forwardForce;
        force += transform.right * horizontal * Time.fixedDeltaTime * sideForce;

        float rotation = xMouseMovement * Time.fixedDeltaTime * sensitivity;

        rb.AddForce(force);
        transform.Rotate(new Vector3(0, rotation, 0));
        
    }
}
