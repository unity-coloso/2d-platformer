using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public string nextLevelName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("플레이어가 목표물(Objective)과 충돌했습니다.");

            // 빈 문자열: ""
            // "Scenes/Level2"
            PlayerPrefs.SetInt(nextLevelName, 1);
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
