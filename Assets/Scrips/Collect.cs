using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    Vector3 rotateValue;
    void Start()
    {
        rotateValue = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
    }
    void Update()
    {
        transform.Rotate(rotateValue * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collect") || other.CompareTag("Poison") || other.CompareTag("Spike"))
        {
            transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0.65f, Random.Range(-4.5f, 4.5f));
            Debug.Log(other.tag);
        }
    }
}
