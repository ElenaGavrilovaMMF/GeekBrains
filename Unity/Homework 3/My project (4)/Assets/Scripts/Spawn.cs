using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    void Awake()
    {
        Vector3 startPosition = transform.position + Vector3.up;
        float rotationY = Random.Range(-180, 180);
        Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, rotationY, transform.rotation.eulerAngles.z);
        gameObject.transform.rotation = Quaternion.Euler(rotation);
        enemy = Instantiate(enemy, startPosition, Quaternion.Euler(rotation));
        enemy.transform.parent = transform.parent;
        gameObject.SetActive(false);
    }
}
