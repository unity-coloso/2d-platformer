using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{
    public List<Button> availableLevels;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        for (int i = 0; i < availableLevels.Count; i++)
        {
            string levelName = $"Scenes/Level{i + 2}";
            bool isUnlocked = PlayerPrefs.GetInt(levelName) == 1 ? true : false;

            Debug.Log(levelName + "_" + isUnlocked);
            availableLevels[i].interactable = isUnlocked;
        }
    }

    void OnClick()
    {
        Debug.Log("New Game ��ư�� ���Ƚ��ϴ�.");

        // ���� PlayerPrefs�� ����� ��� ����� ����.
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < availableLevels.Count; i++)
        {
            // [0][1][2]
            availableLevels[i].interactable = false;
        }
    }
}
