using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockPosX; // -1, 0, 1
    public int blockPosY; // -1, 0, 1
    private Vector2 blockPos;

    void Start()
    {
        blockPos = new Vector2(blockPosX, blockPosY);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // 충돌한 객체가 "Microbe" 태그를 가지고 있다면
        if (collision.CompareTag("0") ||
            collision.CompareTag("1") ||
            collision.CompareTag("2") ||
            collision.CompareTag("3")  )
        {
            // Microbe 객체의 Rigidbody2D 컴포넌트를 가져와서 블록 위치의 반대 방향으로 밀어냄
            Rigidbody2D microbeRb = collision.GetComponent<Rigidbody2D>();
            if (microbeRb != null)
            {
                Vector2 pushDirection = -blockPos.normalized; // 블록 위치의 반대 방향
                microbeRb.AddForce(pushDirection * 500f, ForceMode2D.Force); // 힘의 크기는 5로 설정 (조정 가능)
            }
        }
    }
}
