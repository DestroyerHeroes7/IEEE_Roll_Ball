using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] int collectedCubeCount;
    public Text scoreText;
    public GameObject winText;

    public bool isGround;

    public float x, y;

    bool isGameEnd;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            collectedCubeCount++;
            Destroy(other.gameObject);
            scoreText.text = collectedCubeCount + " / 7";
        }
        else if (other.gameObject.CompareTag("Poison"))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if(collision.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
    private void GameEnd()
    {
        winText.SetActive(true);
        isGameEnd = true;
        rb.isKinematic = true;
    }
    void Update()
    {
        #region Input
        if(!isGameEnd)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            if(Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rb.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
            }
        }
        #endregion
        if (collectedCubeCount >= Global.completedCubeCount)
        {
            GameEnd();
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y, Mathf.Clamp(transform.position.z, -5, 5));
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(x * speed, rb.velocity.y, y * speed);
    }
}
