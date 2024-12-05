using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private Interaction interactableObject = null;
    private bool holdingItem = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!holdingItem || other.GetComponent<ItemPickUp>() == null)
        {
            interactableObject = other.GetComponent<Interaction>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (interactableObject != null && interactableObject == other.GetComponent<Interaction>())
        {
            interactableObject = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableObject != null)
        {
            PerformAction();
        }
    }

    void PerformAction()
    {
        if (interactableObject is ItemPickUp itemPickUp)
        {
            if (itemPickUp.isPickedUp == false)
            {
                holdingItem = true;
                itemPickUp.PickUp();
            }
            else
            {
                holdingItem = false;
                itemPickUp.PickOff();
            }
        }
        else
        {
            interactableObject.Interact();
        }
    }
}