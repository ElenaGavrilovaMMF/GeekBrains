using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoor
{
    public void Init();
    public void Tick();
}

public class DoorController : MonoBehaviour, IDoor
{
    public void Init()
    {
        target = transform.position + transform.localScale.x * Vector3.left;
        startColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }
    
    public void Tick()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = true;
                gameObject.GetComponent<MeshRenderer>().material.color = startColor;
            }
        }
        if (isOpen && transform.position.x > target.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, target,  Time.deltaTime);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Consts.PLAYER_TAG))
        {
            if (!isOpen)
            {
                isActive = true;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(Consts.PLAYER_TAG))
        {
            isActive = false;
            gameObject.GetComponent<MeshRenderer>().material.color = startColor;
        }
    }

    private bool isOpen = false;
    private Vector3 target;
    private bool isActive = false;
    private Color startColor;
}
