using UnityEngine;

public class InGameHud : MonoBehaviour
{
    public GameObject pauseMenu;

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
}