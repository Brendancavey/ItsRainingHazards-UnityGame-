using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public GameObject loseScreen;
    public TextMeshProUGUI healthDisplay;
    Rigidbody2D rb;
    public float speed;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        healthDisplay.text = health.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // player input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

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
