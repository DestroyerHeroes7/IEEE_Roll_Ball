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
    
}
