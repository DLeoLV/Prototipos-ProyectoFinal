using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject prefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float cooldown = 3f;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            GenerateObject();
            timer = 0f;
        }
    }

    void GenerateObject()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 randomPosition = new Vector2(randomX, randomY);
        Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}