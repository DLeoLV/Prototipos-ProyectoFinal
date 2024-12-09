using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickBase;
    private Vector2 inputDirection;
    private Vector2 startPos;

    public float moveSpeed = 5f;

    private PlayerPhoneMovement playerMovement;

    void Start()
    {
        startPos = joystickBackground.position;
        playerMovement = GetComponentInParent<PlayerPhoneMovement>();
    }

    void Update()
    {
        if (inputDirection.magnitude > 0)
        {
            playerMovement.Move(inputDirection * moveSpeed * Time.deltaTime);
        }
    }

    void HandleTouchInput(Vector2 touchPos)
    {
        Vector2 direction = touchPos - startPos;
        float distance = Mathf.Min(direction.magnitude, joystickBackground.rect.width / 2);
        inputDirection = direction.normalized * distance;

        joystickBase.position = startPos + inputDirection;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystickBackground.position = eventData.position;
        joystickBase.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - startPos;
        float distance = Mathf.Min(direction.magnitude, joystickBackground.rect.width / 2);
        inputDirection = direction.normalized * distance;

        joystickBase.position = startPos + inputDirection;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBase.position = startPos;
        inputDirection = Vector2.zero;
    }

    public Vector2 GetInputDirection()
    {
        return inputDirection / (joystickBackground.rect.width / 2);
    }
}
