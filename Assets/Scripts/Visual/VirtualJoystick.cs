using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;
    public float moveThreshold = 1.0f;

    private Vector2 joystickStartPos;
    private Vector2 inputDirection;

    void Start()
    {
        joystickStartPos = joystickBackground.position;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;

            if (!RectTransformUtility.RectangleContainsScreenPoint(joystickBackground, touchPos))
            {
                ResetJoystick();
            }
            else
            {
                Vector2 direction = touchPos - (Vector2)joystickStartPos;
                inputDirection = direction.normalized;

                float distance = Mathf.Min(direction.magnitude, joystickBackground.rect.width / 2);
                joystickHandle.anchoredPosition = new Vector2(inputDirection.x * distance, inputDirection.y * distance);

                UpdatePlayerMovement(inputDirection);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - (Vector2)joystickStartPos;
        inputDirection = direction.normalized;

        float distance = Mathf.Min(direction.magnitude, joystickBackground.rect.width / 2);
        joystickHandle.anchoredPosition = new Vector2(inputDirection.x * distance, inputDirection.y * distance);

        UpdatePlayerMovement(inputDirection);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetJoystick();
    }

    private void ResetJoystick()
    {
        inputDirection = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
        UpdatePlayerMovement(Vector2.zero);
    }

    private void UpdatePlayerMovement(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x, direction.y, 0f); 
        transform.Translate(move * Time.deltaTime, Space.World);
    }

    public Vector2 GetInputDirection()
    {
        return inputDirection;
    }
}
