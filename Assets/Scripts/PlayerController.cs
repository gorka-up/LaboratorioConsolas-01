using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] private Transform bulletExit;
    [SerializeField] private GameObject canon;
    [SerializeField] private GameObject greenBullet;
    [SerializeField] private GameObject redBullet;

    [SerializeField] private Material greenMat;
    [SerializeField] private Material redMat;

    [SerializeField] private PauseMenuController pauseController;


    enum State
    {
        Red , Green
    }

    private State selfState = State.Green;

    private Vector2 move;
    private Vector2 look;

    void Start()
    {
        selfState = State.Green;
    }

    void Update()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log("Device conected in game");
                    pauseController.Continue();
                    break;

                case InputDeviceChange.Removed:
                    Debug.Log("Device disconected in game");
                    pauseController.Pause();
                    break;
            }
        };
    }

    public void OnMove(InputAction.CallbackContext context)
    {
       //move character
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        //move character
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Change();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        pauseController.Pause();
    }
    private void Move(Vector2 movement)
    {
        //move
    }

    private void Look(Vector2 lookTo)
    {
        //look
    }

    private void Attack()
    {
        GameObject bullet;
        switch (selfState)
        {
            case State.Red:
                bullet = Instantiate(redBullet);
                break;
            case State.Green:
                bullet = Instantiate(greenBullet);
                break;
        }
        //give force to bullet
    }

    private void Change()
    {
        if (selfState == State.Green)
        {
            selfState = State.Red;
            this.gameObject.GetComponent<Renderer>().material = greenMat;
        }
        else
        {
            selfState = State.Green;
            this.gameObject.GetComponent<Renderer>().material = redMat;
        }
    }
}
