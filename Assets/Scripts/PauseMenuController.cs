using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    void Start()
    {
        if (pauseMenu.activeSelf) pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Continue()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }

    void Pause()
    {
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
        }
    }
}
