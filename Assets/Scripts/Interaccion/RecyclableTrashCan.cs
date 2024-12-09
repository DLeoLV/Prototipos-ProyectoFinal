using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableTrashCan : MonoBehaviour, Interaction
{
    public static int totalPoints = 0;
    public string recyclingType;
    public GameObject player;
    public CollisionDetector collisionDetector;
    public int visiblePoints;

    void Start()
    {
        collisionDetector = player.GetComponent<CollisionDetector>();
    }

    void Update()
    {
        visiblePoints = totalPoints;
    }

    public void Interact()
    {
        if (collisionDetector != null && collisionDetector.holdingItem && collisionDetector.currentItem != null)
        {
            RecyclableObjectData recyclableData = collisionDetector.currentItem.GetComponent<RecyclableObjectData>();

            if (recyclableData != null && recyclableData.recyclableObject.itemType == recyclingType)
            {
                totalPoints += recyclableData.recyclableObject.itemPoints;
                Destroy(collisionDetector.currentItem.gameObject);
                collisionDetector.DropItem();
            }
            else
            {
                totalPoints -= recyclableData.recyclableObject.itemPoints;
                Destroy(collisionDetector.currentItem.gameObject);
                collisionDetector.DropItem();
            }
        }
    }
}
