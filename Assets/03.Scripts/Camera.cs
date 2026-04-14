using UnityEngine;
using UnityEngine.InputSystem;

// 클래스 이름을 Camera에서 TopDownCamera로 변경하여 충돌 방지
public class TopDownCamera : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float zoomSpeed = 5f;
    public float minSize = 2f;
    public float maxSize = 20f;

    private Vector2 moveInput;
    private float zoomInput;
    private UnityEngine.Camera cam; // 명시적으로 엔진 카메라 클래스 지칭

    void Awake()
    {
        cam = GetComponent<UnityEngine.Camera>();
        var playerInput = GetComponent<PlayerInput>();
        
        // Input Action 설정 (Action 이름이 Move, Zoom인지 확인 필요)
        playerInput.actions["Move"].performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.actions["Move"].canceled += ctx => moveInput = Vector2.zero;
        
        playerInput.actions["Zoom"].performed += ctx => zoomInput = ctx.ReadValue<float>();
        playerInput.actions["Zoom"].canceled += ctx => zoomInput = 0;
    }

    void Update()
    {
        // 이동 (화살표, WASD)
        Vector3 moveDir = new Vector3(moveInput.x, moveInput.y, 0);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        // 줌 (-, = 버튼 대응)
        if (zoomInput != 0)
        {
            // zoomInput이 -1이면 줌아웃(=size증가), 1이면 줌인(=size감소)
            cam.orthographicSize -= zoomInput * zoomSpeed * Time.deltaTime;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);
        }
    }
}