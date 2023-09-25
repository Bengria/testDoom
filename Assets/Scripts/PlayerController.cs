using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardForce = 1;
    [SerializeField] private float sideForce = 1;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontal * Time.fixedDeltaTime * forwardForce, 0, vertical * Time.fixedDeltaTime * sideForce));

        //transform.position += new Vector3(horizontal * Time.deltaTime * forwardForce, 0, vertical * Time.deltaTime * sideForce);
    }
}
