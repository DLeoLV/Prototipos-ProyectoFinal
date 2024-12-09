using UnityEngine;

public class PlayerPhoneMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movement.magnitude > 0)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }
}
