using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : BaseCharacterController
{
    [SerializeField] private float sensitivity = 1;

    protected override void Awake()
    {
        base.Awake();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Rotate(Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
        MoveLocal(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

}