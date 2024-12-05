using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableObjectGenerator : MonoBehaviour
{
    public List<RecyclableObject> recyclableObjects;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;
    public int interval = 1;
    public Transform myPlayer;

    void Start()
    {
        InvokeRepeating("GenerateObject", 0f, interval);
    }

    void GenerateObject()
    {
        // Selecciona aleatoriamente un ScriptableObject de la lista
        RecyclableObject randomRecyclableObject = recyclableObjects[Random.Range(0, recyclableObjects.Count)];

        // Genera una posición aleatoria dentro del rango especificado
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);

        // Crea un nuevo GameObject vacío
        GameObject newObject = new GameObject(randomRecyclableObject.itemName);

        // Establecer la posición aleatoria
        newObject.transform.position = randomPosition;

        // Añadir SpriteRenderer al nuevo GameObject y asignar el sprite
        SpriteRenderer spriteRenderer = newObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = randomRecyclableObject.itemSprite;

        // Añadir Rigidbody2D y BoxCollider2D si es necesario
        //newObject.AddComponent<Rigidbody2D>();
        BoxCollider2D boxCollider = newObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        // Asigna una referencia al ScriptableObject
        RecyclableObjectData recyclableData = newObject.AddComponent<RecyclableObjectData>();
        recyclableData.recyclableObject = randomRecyclableObject;

        ItemPickUp itemPickUp = newObject.AddComponent<ItemPickUp>();
        itemPickUp.Setup(myPlayer);
    }
}