using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DemoController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float rotationSpeed = 100f;

    public Button moveUpButton;  
    public Button moveDownButton;  
    public Button moveLeftButton;  
    public Button moveRightButton;  
    public Button rotateLeftButton;  
    public Button rotateRightButton;  
    public Button moveForwardButton;  
    public Button moveBackwardButton;  

    private bool moveUpPressed = false;
    private bool moveDownPressed = false;
    private bool moveLeftPressed = false;
    private bool moveRightPressed = false;
    private bool rotateLeftPressed = false;
    private bool rotateRightPressed = false;
    private bool moveForwardPressed = false;
    private bool moveBackwardPressed = false;

    void Start()
    {
        AddButtonListeners(moveUpButton, "MoveUp");
        AddButtonListeners(moveDownButton, "MoveDown");
        AddButtonListeners(moveLeftButton, "MoveLeft");
        AddButtonListeners(moveRightButton, "MoveRight");
        AddButtonListeners(rotateLeftButton, "RotateLeft");
        AddButtonListeners(rotateRightButton, "RotateRight");
        AddButtonListeners(moveForwardButton, "MoveForward");
        AddButtonListeners(moveBackwardButton, "MoveBackward");
    }

    void Update()
    {
        float moveX = -Input.GetAxis("Horizontal");
        float moveY = -Input.GetAxis("Vertical");
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.R))
        {
            moveZ = -1f;
        }
        else if (Input.GetKey(KeyCode.F))
        {
            moveZ = 1f;
        }

        Vector3 movement = new Vector3(moveX, moveY, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);


        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
        }

        if (moveUpPressed)
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);

        if (moveDownPressed)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);

        if (moveLeftPressed)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World); 

        if (moveRightPressed)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World); 

        if (rotateLeftPressed)
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);

        if (rotateRightPressed)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        if (moveForwardPressed)
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);

        if (moveBackwardPressed)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
    }

    private void AddButtonListeners(Button button, string action)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        pointerDown.callback.AddListener((data) => OnPointerDown(action));
        trigger.triggers.Add(pointerDown);

        EventTrigger.Entry pointerUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        pointerUp.callback.AddListener((data) => OnPointerUp(action));
        trigger.triggers.Add(pointerUp);
    }

    private void OnPointerDown(string action)
    {
        switch (action)
        {
            case "MoveUp": moveUpPressed = true; break;
            case "MoveDown": moveDownPressed = true; break;
            case "MoveLeft": moveLeftPressed = true; break;
            case "MoveRight": moveRightPressed = true; break;
            case "RotateLeft": rotateLeftPressed = true; break;
            case "RotateRight": rotateRightPressed = true; break;
            case "MoveForward": moveForwardPressed = true; break;
            case "MoveBackward": moveBackwardPressed = true; break;
        }
    }

    private void OnPointerUp(string action)
    {
        switch (action)
        {
            case "MoveUp": moveUpPressed = false; break;
            case "MoveDown": moveDownPressed = false; break;
            case "MoveLeft": moveLeftPressed = false; break;
            case "MoveRight": moveRightPressed = false; break;
            case "RotateLeft": rotateLeftPressed = false; break;
            case "RotateRight": rotateRightPressed = false; break;
            case "MoveForward": moveForwardPressed = false; break;
            case "MoveBackward": moveBackwardPressed = false; break;
        }
    }
}
