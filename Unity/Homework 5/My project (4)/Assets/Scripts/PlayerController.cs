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
    public float shootForce = 10f;
    public float jumpPower = 1f;
    public float jumpHigth = 2f;
    public GameObject weapon;
    public GameObject bomb;

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

        Bomb();
        Shoot();
        Jump(forwardForce);
    }

    private void Bomb()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _currentBomb = Instantiate(bomb, transform.position - 2f*transform.forward, Quaternion.identity);
        }
    }
    
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentWeapon = Instantiate(weapon, transform.position + Vector3.up, Quaternion.identity);
            _currentWeapon.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            _currentWeapon.transform.parent = transform;
            Rigidbody _rigidbodyWeapon = _currentWeapon.GetComponent<Rigidbody>();
            _rigidbodyWeapon.AddForce(-shootForce * gameObject.transform.forward, ForceMode.Impulse);
        }
    }
    
    private void Jump(float forwardForce)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJump = true;
            if (forwardForce == 0.0f)
            {
                _rigitbody.AddForce((jumpHigth + jumpPower) * Vector3.up, ForceMode.Impulse);
            }
        }
        
        if (forwardForce != 0.0f)
        {
            if (isJump)
            {
                if (transform.position.y < jumpPower)
                {
                    transform.position += (jumpPower+jumpHigth)*Vector3.up * Time.deltaTime;
                }
                else
                {
                    isJump = false;
                }
            }
            if (!isGround && !isJump)
            {
                transform.position -= jumpPower*Vector3.up * Time.deltaTime;
            }
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
    
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals(Consts.GROUND_TAG))
        {
            isGround = true;
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals(Consts.GROUND_TAG))
        {
            isGround = false;
        }
    }
    
    public float GetHealth()
    {
        return health;
    }
    
    private Rigidbody _rigitbody;
    private GameObject _currentWeapon;
    private GameObject _currentBomb;
    private bool isGround = false;
    private bool isJump = false;
}
