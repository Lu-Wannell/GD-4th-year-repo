using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float jumpStep = 1f;
    [SerializeField] private float rotateSpeed = 180f;

    private Vector2 lookInput;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal; look rotates around Y (turn left/right)
        float yaw = lookInput.x * rotateSpeed * Time.deltaTime;
        transform.Rotate(0f, yaw, 0f, Space.World);

        Vector3 move3 = new Vector3(moveInput.x, 0f, moveInput.y) * MoveSpeed * Time.deltaTime;
        transform.position += move3;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //performed = dpad moved and cancelled = dpad released
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return; //ensures it only triggers once per press
        transform.position += Vector3.up * jumpStep;
    }

    public void OnShoot(InputAction.CallbackContext context)
    { }


}
