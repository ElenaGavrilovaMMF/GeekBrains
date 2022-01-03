using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellow : MonoBehaviour
{
    public float _speed = 0.1f;
    
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
            isAtack = false;
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
    
   
    void Update()
    {
        if (isAtack)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos+Vector3.up, _speed * Time.deltaTime);
        }
    }
    private Vector3 playerPos;
    private Transform _pellet;
    private bool isAtack = false;
}
