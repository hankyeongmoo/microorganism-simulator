using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    [Header("Camera Settings")]
    public float moveSpeed = 5f;
    public float zoomSpeed = 5f;

    [Header("Input Actions")]
    public InputAction moveAction;
    public InputAction zoomAction;

    [Header("References")]
    private Rigidbody2D rb;

    void Awake()
    {
        moveAction = GetComponent<PlayerInput>().actions["Move"];
        zoomAction = GetComponent<PlayerInput>().actions["Zoom"];

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0).normalized;
        rb.AddForce(moveDir * moveSpeed * Time.deltaTime);
    }
}
