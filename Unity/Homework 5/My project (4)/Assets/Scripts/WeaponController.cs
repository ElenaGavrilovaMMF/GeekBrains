using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    public float radius = 5f;
    public float force = 700f;

    void Start()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(Consts.ENEMY_TAG))
        {
            Explode();
        }
        else
        {
            if (!collision.gameObject.tag.Equals(Consts.PLAYER_TAG))
            {
                Destroy(gameObject);
            }
        }
    }
    
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearlyObject in colliders)
        {
            Rigidbody rb = nearlyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                Destroy(gameObject);
            }
        }
    }
}
