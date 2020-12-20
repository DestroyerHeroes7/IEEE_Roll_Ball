using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] int collectedCubeCount;
    public Text scoreText;
    public GameObject winText;

    bool isGameEnd;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            collectedCubeCount++;
            Destroy(other.gameObject);
            scoreText.text = collectedCubeCount + " / 7";
        }
    }
    private void GameEnd()
    {
        winText.SetActive(true);
        isGameEnd = true;
        rb.velocity = Vector3.zero;
    }
    void Update()
    {
        #region Input
        if(!isGameEnd)
        {
            if (Input.GetKey(KeyCode.DownArrow))
                rb.AddForce(Vector3.back * speed);
            if (Input.GetKey(KeyCode.UpArrow))
                rb.AddForce(Vector3.forward * speed);
            if (Input.GetKey(KeyCode.RightArrow))
                rb.AddForce(Vector3.right * speed);
            if (Input.GetKey(KeyCode.LeftArrow))
                rb.AddForce(Vector3.left * speed);
        }
        #endregion
        if (collectedCubeCount >= Global.completedCubeCount)
        {
            GameEnd();
        }
    }
}
