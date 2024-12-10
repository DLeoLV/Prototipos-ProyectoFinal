using UnityEngine;

public class PlayerPhoneMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public VirtualJoystick joystick;

    void Update()
    {
        Vector2 direction = joystick.GetInputDirection();
        Vector3 move = new Vector3(direction.x, direction.y, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
