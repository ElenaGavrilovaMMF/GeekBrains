using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{
    private Vector3 startPos;

    void Awake()
    {
        startPos = transform.localPosition;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        transform.localPosition = startPos;
    }
}
