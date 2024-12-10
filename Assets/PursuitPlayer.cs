using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitPlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.position = new Vector3(initialPosition.x, target.position.y, initialPosition.z);
    }
}