using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Running = 0,
        Paused = 1
    }

    static GameManager _instance;

    // 싱글턴(Singleton) 패턴
    // 한 번에 2개 이상 생기지 않도록 한정시키는(제한시키는) 패턴.
    public static GameManager Instance
    {
        // 프로퍼티(Property)
        get
        {
            _instance = FindObjectOfType<GameManager>();

            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public GameState State
    {
        // get: 읽기 전용 프로퍼티.
        get
        {
            return state;
        }
    }
    [SerializeField] GameState state;
    InGameHud hud;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 중복된 GameManager가 존재하는 경우.
        else
        {
            GameObject.Destroy(gameObject);
        }

        hud = FindObjectOfType<InGameHud>();
    }

    public void ResumeGame()
    {
        state = GameState.Running;
        hud.ClosePauseMenu();
        Time.timeScale = 1f;
    }

    public void OpenMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Debug.Log("게임 오버되었습니다.");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        // ESC 키가 눌렸을 경우 실행
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == GameState.Running)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        state = GameState.Paused;
        hud.OpenPauseMenu();
        Time.timeScale = 0f;
    }
}
