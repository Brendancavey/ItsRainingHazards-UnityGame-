using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private float moveHorizontal;
    public GameObject loseScreen;
    public TextMeshProUGUI healthDisplay;
    Rigidbody2D rb;
    Animator playerAnimation;
    public float speed;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        healthDisplay.text = health.ToString();
    }
    private void Update()
    {
        //setting player animation when moving
        if(moveHorizontal != 0)
        {
            playerAnimation.SetBool("isRunning", true);
        }
        else
        {
            playerAnimation.SetBool("isRunning", false);
        }

        //flipping character sprite depending on direction
        if (moveHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // player input
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        //moving player
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    public void TakeDamage(int dmgAmount)
    {
        health--;
        
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            loseScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
