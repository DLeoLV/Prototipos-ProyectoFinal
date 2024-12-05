using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RecyclableObjectScript", menuName = "Scripts/RecyclableObject")]
public class RecyclableObject : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public string itemType;
    public int itemPoints;
}