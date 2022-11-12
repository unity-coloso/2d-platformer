using UnityEngine;
using UnityEngine.UI;

public class HudKey : MonoBehaviour
{
    public Sprite hasKeySprite;
    public Sprite hasNoKeySprite;

    PlayerController player;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        // �÷��̾� ������Ʈ �̸� ����(ĳ��; caching).
        player = FindObjectOfType<PlayerController>();

        // �̹��� ������Ʈ �̸� ����.
        image = GetComponent<Image>();

        // ���� GameObject�� ���縦 �˻�.
        GameObject key = GameObject.FindGameObjectWithTag("Key");
        if (key == null)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        if (player.hasKey)
        {
            image.sprite = hasKeySprite;
        }
        else
        {
            image.sprite = hasNoKeySprite;
        }
    }
}
