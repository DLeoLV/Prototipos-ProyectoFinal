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
        //if (collisionDetector != null && collisionDetector.holdingItem == true && collisionDetector.interactableObject != null)
        //{
        //    RecyclableObjectData recyclableData = collisionDetector.interactableObject.recyclingTypeName;

        //    if (recyclableData != null && recyclableData.recyclableObject.itemType == recyclingType)
        //    {
        //        totalPoints += recyclableData.recyclableObject.itemPoints;
        //        Destroy(collisionDetector.interactableObject.gameObject);
        //        collisionDetector.DropItem();
        //    }
        //}
    }
}