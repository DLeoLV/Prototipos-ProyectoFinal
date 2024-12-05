using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour, Interaction
{
    public GameObject panel;

    public void Interact()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}