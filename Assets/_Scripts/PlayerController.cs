using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1;
    [SerializeField] private float speed;

    private Vector3 surfaceNormal;

    private CharacterController characterController;
    private float verticalSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
        transform.Rotate(rotation);

        if (characterController.isGrounded)
            verticalSpeed = -0.1f;
        else
            verticalSpeed += Physics.gravity.y * Time.deltaTime;
        
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1);

        Vector3 velocity = transform.TransformDirection(input) * speed;

        Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.up, surfaceNormal);
        Vector3 adjustedVelocity = slopeRotation * velocity;

        velocity = adjustedVelocity.y < 0 ? adjustedVelocity : velocity;

        velocity.y += verticalSpeed;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        surfaceNormal = hit.normal;

        Debug.DrawLine(hit.point, hit.point + surfaceNormal * 3, Color.red);
    }
}
