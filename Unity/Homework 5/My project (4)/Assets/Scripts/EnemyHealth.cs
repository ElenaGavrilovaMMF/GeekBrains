using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    void Awake()
    {
        startValue = transform.position;
        health = GetComponentInParent<EnemyYellow>().GetHealth();
        part = transform.localScale.x / health;
    }
    
    void Update()
    {
        if (part * health <= 0f)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        health = GetComponentInParent<EnemyYellow>().GetHealth();
        transform.localScale =  new Vector3(part * health, transform.localScale.y, transform.localScale.z);
    }
    
    private float health;
    private Vector3 startValue;
    private float part;
}
