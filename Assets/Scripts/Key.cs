using UnityEngine;

public class Key : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ����(Key)�� �浹�߽��ϴ�.");

            // ���� ȹ�� ó��.
            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            player.hasKey = true;

            // ���� �Ҹ� ó��.
            GameObject.Destroy(gameObject);
        }
    }
}
