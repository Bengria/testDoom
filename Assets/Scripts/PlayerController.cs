using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private float forwardForce = 1;
    [SerializeField] private float sideForce = 1;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
=======
    [SerializeField] float forwardForce = 1000;
    [SerializeField] float sideForce = 1000;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
>>>>>>> 1f599d83239de20414470c88e778c8efff1993e5
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontal * Time.fixedDeltaTime * forwardForce, 0, vertical * Time.fixedDeltaTime * sideForce));

<<<<<<< HEAD
        //transform.position += new Vector3(horizontal * Time.deltaTime * forwardForce, 0, vertical * Time.deltaTime * sideForce);
=======
        
>>>>>>> 1f599d83239de20414470c88e778c8efff1993e5
    }
}
