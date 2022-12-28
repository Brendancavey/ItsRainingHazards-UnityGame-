using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
