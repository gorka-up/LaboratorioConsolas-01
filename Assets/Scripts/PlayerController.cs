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

    enum State
    {
        Red , Green
    }

    private State selfState = State.Green;

    private InputAction move;
    private InputAction look;
    private InputAction attack;
    private InputAction interact;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        look = InputSystem.actions.FindAction("Look");
        attack = InputSystem.actions.FindAction("Attack");
        interact = InputSystem.actions.FindAction("Interact");

        selfState = State.Green;
    }

    void Update()
    {
        Vector2 moveValue = move.ReadValue<Vector2>();
        Move(moveValue);

        Vector2 lookValue = look.ReadValue<Vector2>();
        Look(lookValue);


        if (attack.IsPressed())
        {
            Attack();
        }

        if (interact.IsPressed())
        {
            Change();
        }
    }

    private void Move(Vector2 movement)
    {

    }

    private void Look(Vector2 lookTo)
    {

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
