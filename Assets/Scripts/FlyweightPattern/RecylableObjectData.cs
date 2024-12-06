using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableObjectData : MonoBehaviour
{
    public RecyclableObject recyclableObject;
    public string recyclingTypeName;
    void Start()
    {
        recyclingTypeName = recyclableObject.itemType;
    }
}
