using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableTrashCan : MonoBehaviour, Interaction
{
    public static int totalPoints = 0;
    public string recyclingType;
    public GameObject player;
    public CollisionDetector collisionDetector;

    void Start()
    {
        collisionDetector = player.GetComponent<CollisionDetector>();
    }

    public void Interact()
    {
        if (collisionDetector != null && collisionDetector.holdingItem && collisionDetector.interactableMonoBehaviour != null)
        {
            RecyclableObjectData recyclableData = collisionDetector.interactableMonoBehaviour.GetComponent<RecyclableObjectData>();

            if (recyclableData != null && recyclableData.recyclableObject.itemType == recyclingType)
            {
                totalPoints += recyclableData.recyclableObject.itemPoints;
                Destroy(collisionDetector.interactableMonoBehaviour.gameObject);
                collisionDetector.DropItem();
            }
        }
    }
}