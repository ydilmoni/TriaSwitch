using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float startRedAngle, endRedAngle, startGreenAngle, endGreenAngle, startBlueAngle, endBlueAngle;

    private float currentAngle, jumpCounter = 0;
    [SerializeField]
    InputAction moveRight = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveLeft = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveUp = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveDown = new InputAction(type: InputActionType.Button);

    [SerializeField]
    [Tooltip("How many meters per second to move when action is pressed")]
    private float speed = 7, jumpForce = 15f, maxjump = 3;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    string currentGroundTag = "Red";
    string bottomTringle = "Red";

    public bool CanMove()
    {
        return (bottomTringle == currentGroundTag || currentGroundTag == "Joker");
    }
    private void OnEnable()
    {
        moveRight.Enable();
        moveLeft.Enable();
        moveUp.Enable();
        moveDown.Enable();
    }

    private void OnDisable()
    {
        moveRight.Disable();
        moveLeft.Disable();
        moveUp.Disable();
        moveDown.Disable();
    }
    private void Update()
    {
        if (CanMove())
        {
            if (moveRight.IsPressed())
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            if (moveLeft.IsPressed())
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            if (moveDown.IsPressed())
            {
                // Debug.Log("Moving down");
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
        if (moveUp.IsPressed() && jumpCounter <= maxjump)
        {
            rb.AddForce(new Vector2(0, speed * jumpForce));
            jumpCounter++;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.tag);
        currentGroundTag = collision.gameObject.tag;
        currentAngle = transform.eulerAngles.z;
        jumpCounter = 0;
        Debug.Log("Current angle: " + currentAngle);
        if (currentAngle > startRedAngle && currentAngle < endRedAngle)
        {
            bottomTringle = "Red";
            Debug.Log("Bottom triangle is Red");
        }
        else if (currentAngle > startGreenAngle && currentAngle < endGreenAngle)
        {
            bottomTringle = "Green";
            Debug.Log("Bottom triangle is Green");
        }
        else if (currentAngle > startBlueAngle && currentAngle < endBlueAngle)
        {
            bottomTringle = "Blue";
            Debug.Log("Bottom triangle is Blue");
        }
        Debug.Log($"Can move?: {(bottomTringle == currentGroundTag) || currentGroundTag == "Joker"} Because bottomTringle is {bottomTringle} and currentGroundTag is {currentGroundTag}");
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        string currentGroundTag = collision.gameObject.tag;
    }
}



