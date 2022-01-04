using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Pharmacy : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(Rotate());
    }
    
    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Rotate()
    {
        yield return new WaitForSeconds(TIME);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - ANGLE_STEP,
            transform.rotation.eulerAngles.z);
    }

    private readonly static float TIME = 0.5f;
    private readonly static float ANGLE_STEP = 0.5f;

}
