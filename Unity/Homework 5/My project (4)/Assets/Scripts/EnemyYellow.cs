using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellow : MonoBehaviour
{
    public float _speed = 3f;
    public float health = 10f;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Consts.PLAYER_TAG))
        {
            isAtack = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(Consts.PLAYER_TAG))
        {
            StartCoroutine(Wait());
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(Consts.PLAYER_TAG))
        {
            transform.LookAt(other.transform, Vector3.up);
            playerPos = other.gameObject.transform.position;
        }
    }
    
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        isAtack = false;
    }
    
    void Update()
    {
        if (isAtack)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos+Vector3.up, _speed * Time.deltaTime);
        }
    }

    public float GetHealth()
    {
        return health;
    }
    
    public void SetHealth(float health)
    {
        this.health = health;
    }
    
    private Vector3 playerPos;
    private Transform _pellet;
    private bool isAtack = false;
}
