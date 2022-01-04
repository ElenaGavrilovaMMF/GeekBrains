using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float radius = 2f;
    public float force = 5f;

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearlyObject in colliders)
        {
            Rigidbody rb = nearlyObject.GetComponent<Rigidbody>();
            if (rb != null && !rb.tag.Equals(Consts.PLAYER_TAG))
            {
                rb.AddForce(-force * (transform.position - rb.transform.position).normalized, ForceMode.Impulse);
                if (rb.tag.Equals(Consts.ENEMY_TAG))
                {
                    EnemyYellow enemyYellow = rb.gameObject.GetComponent<EnemyYellow>();
                    float health = enemyYellow.GetHealth() - 1f;
                    enemyYellow.SetHealth(health);
                }
                Destroy(gameObject);
            }
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Equals(Consts.GROUND_TAG) && !collision.gameObject.tag.Equals(Consts.PLAYER_TAG))
        {
            Explode();
        }
    }
}
