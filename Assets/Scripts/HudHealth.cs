using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHealth : MonoBehaviour
{
    public Sprite hasHealthSprite;
    public Sprite hasNoHealthSprite;

    //  0  1  2  3  4
    // [][][][][]
    public List<Image> hearts = new List<Image>();

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < player.health)
            {
                hearts[i].sprite = hasHealthSprite;
            }
            else
            {
                hearts[i].sprite = hasNoHealthSprite;
            }
        }
    }
}
