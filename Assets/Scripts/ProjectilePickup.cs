using UnityEngine;

public class ProjectilePickup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ �߻�ü �Ⱦ�(Projectile Pickup)�� �浹�߽��ϴ�.");

            // �߻�ü ȹ�� ó��.
            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            player.hasProjectile = true;

            // �߻�ü �Ҹ� ó��.
            GameObject.Destroy(gameObject);
        }
    }
}
