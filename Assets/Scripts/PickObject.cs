using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour, Interaction
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}