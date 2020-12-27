using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Transform> collectibles;
    public List<Transform> spikes;
    void Start()
    {
        foreach(Transform t in collectibles)
        {
            float rX = Random.Range(-4.5f, 4.5f);
            float rZ = Random.Range(-4.5f, 4.5f);
            try
            {
                while (rX > -1 && rX < 1 && rZ > -1 && rZ < 1)
                {
                    rX = Random.Range(-4.5f, 4.5f);
                    rZ = Random.Range(-4.5f, 4.5f);
                }
            }
            catch
            {
                Debug.LogError("Infinite Loop");
            }
            t.position = new Vector3(rX, 0.65f, rZ);
        }
        foreach (Transform t in spikes)
        {
            float rX = Random.Range(-3f, 3f);
            float rZ = Random.Range(-3f, 3f);
            try
            {
                while (rX > -2 && rX < 2 && rZ > -2 && rZ < 2)
                {
                    rX = Random.Range(-3f, 3f);
                    rZ = Random.Range(-3f, 3f);
                }
            }
            catch
            {
                Debug.LogError("Infinite Loop");
            }
            t.position = new Vector3(rX, 0.45f, rZ);
        }
    }
    void Update()
    {
        
    }
}
