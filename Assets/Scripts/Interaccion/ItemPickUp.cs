using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, Interaction
{
    public Transform myPlayer;
    public bool isPickedUp = false;

    public void Setup(Transform playerTransform)
    {
        myPlayer = playerTransform;
    }

    public void Interact()
    {
        if (isPickedUp == false)
        {
            PickUp();
        }
        else
        {
            PickOff();
        }
    }

    public void PickUp()
    {
        isPickedUp = true;
        transform.SetParent(myPlayer);
        transform.localPosition = new Vector3(0f, 6f, 0f);
    }

    public void PickOff()
    {
        isPickedUp = false;
        transform.SetParent(null);
        transform.localPosition = Vector3.zero;
    }
}