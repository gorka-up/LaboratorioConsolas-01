using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("Pause Menu Canvas")]
    [SerializeField] private  GameObject pauseMenu;

    [Header("Buttons")]
    [SerializeField] private  Button continueButton;
    [SerializeField] private  Button mainMenuButton;

    private bool isPaused = false;

    void Start()
    {
        if (pauseMenu.activeSelf) pauseMenu.SetActive(false);
        isPaused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public  void Continue()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            //Unpause game
            EliminateFocus();
        }
    }

    public  void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }

    public  void Pause()
    {
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            //PauseGame
            GiveFocusContinue();
        }
        else
        {
            Continue();
        }
    }

    public void GiveFocusContinue()
    {
        continueButton.Select();
    }

    public void EliminateFocus()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Continue();
        }
        else
        {
            Pause();
        }
    }
}
