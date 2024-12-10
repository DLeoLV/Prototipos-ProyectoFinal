using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private MonoBehaviour leer = null;
    private Interaction interactableObject = null;
    public bool holdingItem = false;
    public ItemPickUp currentItem = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!holdingItem || other.GetComponent<ItemPickUp>() == null)
        {
            interactableObject = other.GetComponent<Interaction>();
            leer = other.GetComponent<MonoBehaviour>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (interactableObject != null && interactableObject == other.GetComponent<Interaction>())
        {
            interactableObject = null;
            leer = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableObject != null)
        {
            PerformAction();
            leer = null;
        }
    }

    public void PerformAction()
    {
        if (interactableObject is ItemPickUp itemPickUp)
        {
            if (!holdingItem)
            {
                holdingItem = true;
                currentItem = itemPickUp;
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
        currentItem = null;
    }

    public Interaction GetInteractableObject()
    {
        return interactableObject;
    }
}
