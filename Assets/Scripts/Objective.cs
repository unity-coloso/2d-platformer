using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public string nextLevelName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ��ǥ��(Objective)�� �浹�߽��ϴ�.");

            // �� ���ڿ�: ""
            // "Scenes/Level2"
            PlayerPrefs.SetInt(nextLevelName, 1);
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
