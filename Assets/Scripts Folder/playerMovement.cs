using UnityEngine;
using UnityEngine.InputSystem; // needed for the new Input System (WASD / controller)

public class playerMovement : MonoBehaviour // script that controls player movement
{
    private Vector2 movement; // stores movement direction from input (x = left/right, y = up/down)
    private Rigidbody2D myBody; // Rigidbody2D used to move the player with physics
    private Animator myAnimator; // Animator that controls walking and idle animations

    [SerializeField] private int speed; // how fast the player moves (editable in Inspector)

    private void Awake() // runs once when the object is created
    {
        myBody = GetComponent<Rigidbody2D>(); // gets the Rigidbody2D component from the player
        myAnimator = GetComponent<Animator>(); // gets the Animator component from the player
    }

    private void OnMovement(InputValue value) // called by the Input System when movement input happens
    {
        movement = value.Get<Vector2>(); // reads WASD input and stores it as a Vector2

        if (movement.x != 0 || movement.y != 0) // checks if the player is moving
        {
            myAnimator.SetFloat("x", movement.x); // sends horizontal direction to Animator
            myAnimator.SetFloat("y", movement.y); // sends vertical direction to Animator
            myAnimator.SetBool("isWalking", true); // tells Animator to play walking animation
        }
        else // runs when there is no movement input
        {
            myAnimator.SetBool("isWalking", false); // stops walking animation (idle)
        }
    }

    private void FixedUpdate() // runs at a fixed rate, used for physics updates
    {
        myBody.linearVelocity = movement * speed; // moves the player based on direction and speed
    }
}

