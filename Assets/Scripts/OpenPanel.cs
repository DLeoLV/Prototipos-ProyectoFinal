using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour, Interaction
{
    public GameObject panel;
    public GameObject joystick;

    public void Interact()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            joystick.SetActive(true);
        }
        else
        {
            panel.SetActive(true);
            joystick.SetActive(false);
        }
    }
}