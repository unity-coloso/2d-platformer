using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openedDoorSprite;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("플레이어가 문(Door)과 충돌했습니다.");

            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            if (player == null)
            {
                return;
            }

            if (player.hasKey)
            {
                // 플레이어 열쇠를 뺏기.
                player.hasKey = false;

                // 열린 문 처리.
                spriteRenderer.sprite = openedDoorSprite;
                boxCollider2d.enabled = false;
            }
        }
    }
}
