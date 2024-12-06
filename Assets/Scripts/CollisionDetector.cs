using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] public MonoBehaviour interactableMonoBehaviour = null;
    public Interaction interactableObject = null;
    public bool holdingItem = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!holdingItem || other.GetComponent<ItemPickUp>() == null)
        {
            interactableObject = other.GetComponent<Interaction>();
            interactableMonoBehaviour = other.GetComponent<MonoBehaviour>();
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
            interactableMonoBehaviour = null;
        }
    }

    void PerformAction()
    {
        if(interactableObject is ItemPickUp itemPickUp)
        {
            if(!holdingItem)
            {
                holdingItem = true;
                itemPickUp.Interact();
            }
        }
        else
        {
            interactableObject.Interact();
        }
    }

    public void DropItem()
    {
        holdingItem = false;
    }
}