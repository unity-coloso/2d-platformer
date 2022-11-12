using UnityEngine;

public class Key : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("ÇÃ·¹ÀÌ¾î°¡ ¿­¼è(Key)¿Í Ãæµ¹Çß½À´Ï´Ù.");

            // ¿­¼è È¹µæ Ã³¸®.
            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            player.hasKey = true;

            // ¿­¼è ¼Ò¸ê Ã³¸®.
            GameObject.Destroy(gameObject);
        }
    }
}
