using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Libriarian : MonoBehaviour
{
    
    Rigidbody2D rb;

    [Header("Stats")]
    [SerializeField] int health = 3;
    LifeCounter lifeCounter; // Reference to the LifeCounter script

    [Header("Physics")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float minYForGameOver = -10f;
    [SerializeField] float jumpOffset = -.5f;
    [SerializeField] float jumpRadius = 2f;
    [SerializeField] float speed = 4f;

    [Header("Jump Physics")]
    [SerializeField] float jumpForce = 12;
    [SerializeField] float extraJumpForce = .5f;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        // Check if the player falls below the minYForGameOver
        if (transform.position.y < minYForGameOver)
        {
            // Delete playerprefs for life counter
            PlayerPrefs.DeleteKey("CurrentHearts");

            // Delete playerprefs for point counter
            PlayerPrefs.DeleteKey("PointsCollected");
            // Load the menu scene
            SceneManager.LoadScene("Menu");
        }
    }

    public void MovePlayer(float direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        //transform.position += direction * Time.deltaTime * speed;
    }

    public void Jump()
    {
        bool isGrounded = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, jumpOffset, 0), jumpRadius, groundLayer).Length > 0;

        if (isGrounded)
        {
          rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetKey(KeyCode.Space) && rb.velocity.y > 0)
        {
        rb.AddForce(Vector2.up * extraJumpForce, ForceMode2D.Force);
        Debug.Log("Holding Space");
        }
    }

    public void PickUpApple(){
        PointCounter.singleton.RegisterPoint();
        GetComponent<AudioSource>().Play();
    }
}
