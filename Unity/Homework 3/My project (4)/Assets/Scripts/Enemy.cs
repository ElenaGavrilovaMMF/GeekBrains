using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    public float _shootSpeed = 3f;

    public void Awake()
    {
        GameObject pelletController = GetComponentInChildren<PelletController>().gameObject;
        _pellet = pelletController.transform;
        pelletController.SetActive(false);
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(Consts.PLAYER_TAG))
        {
            _pellet.gameObject.SetActive(true);
            transform.LookAt(other.transform, Vector3.up);
            playerPos = other.gameObject.transform.position;
            _pellet.position = Vector3.MoveTowards(_pellet.position, playerPos, _shootSpeed * Time.deltaTime);

        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(Consts.PLAYER_TAG))
        {
            _pellet.gameObject.SetActive(false);
        }
    }

    private Vector3 playerPos;
    private Transform _pellet;
    private bool isAtack = false;
}
