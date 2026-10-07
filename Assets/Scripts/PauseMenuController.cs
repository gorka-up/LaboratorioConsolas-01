using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("Pause Menu Canvas")]
    [SerializeField] private GameObject pauseMenu;

    [Header("Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuButton;

    private bool isPaused = false;

    void Start()
    {
        if (pauseMenu.activeSelf) pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Continue()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            //Unpause game
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }

    public void Pause()
    {
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            //PauseGame
            continueButton.Select();
        }
    }
}
