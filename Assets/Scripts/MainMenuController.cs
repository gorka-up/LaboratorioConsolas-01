using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("MainMenu Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button pipeButton;
    [SerializeField] private Button exitButton;


    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        playButton.Select();
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pipe()
    {
        //make sound
    }
}
