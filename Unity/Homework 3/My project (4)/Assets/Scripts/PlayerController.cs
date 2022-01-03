using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IPlayer
{
    public void Init();
    public void Tick();
    public float GetHealth();
}

public class PlayerController : MonoBehaviour, IPlayer
{

    public float rotationSpeed;
    public float movementSpeed;
    public float health = 15f;
    public GameObject weapon;

    public void Init()
    {
        _rigitbody = GetComponent<Rigidbody>();
    }

    public void Tick()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;
        if (sideForce != 0.0f)
        {
            _rigitbody.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }
        float forwardForce = Input.GetAxis("Vertical") * (-movementSpeed);
        if (forwardForce != 0.0f)
        {
            _rigitbody.velocity = _rigitbody.transform.forward * forwardForce;
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(weapon, transform.position + Vector3.up, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Consts.PHARMACY_TAG))
        {
            health+=3f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(Consts.PELLET_TAG))
        {
            health--;
        }
    }
    
    public float GetHealth()
    {
        return health;
    }
    
    private Rigidbody _rigitbody;
}
