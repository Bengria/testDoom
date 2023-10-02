using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1;
    [SerializeField] private float speed;


    private CharacterController characterController;
    private float verticalSpeed = 0;
    private Vector3 surfaceNormal;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float xMouseMovement = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float rotation = xMouseMovement * Time.deltaTime * sensitivity;

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = Vector3.ProjectOnPlane(moveDirection, surfaceNormal);

        Debug.DrawLine(transform.position, moveDirection * 5, Color.blue);


        if (characterController.isGrounded)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed -= 9.8f * Time.deltaTime;
        }

        characterController.Move((moveDirection * speed + Vector3.up * verticalSpeed) * Time.deltaTime);

        transform.Rotate(new Vector3(0, rotation, 0));

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        surfaceNormal = hit.normal;

        Debug.DrawLine(hit.point, hit.point + surfaceNormal * 3, Color.red);
    }
}
