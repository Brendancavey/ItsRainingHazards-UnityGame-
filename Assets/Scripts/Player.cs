using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
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
    private float difficultyTimer;
    public float startDifficultyTimer;
    public float difficultyScale;
    public float increaseDifficulty;
    public GameObject coin;
    public Transform[] spawnPoints;
    public CameraShake camera;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        
        healthDisplay.text = health.ToString();
    }
    private void Update()
    {
        //setting a difficulty scale for enemy movement speed and spawn timer
        if(difficultyTimer <= 0)
        {
            //increase difficulty
            difficultyScale +=increaseDifficulty;
            difficultyTimer = startDifficultyTimer; //every startDifficultyTimer(seconds), increase difficulty scale

            //spawn a reward coin
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(coin, randomSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            difficultyTimer -= Time.deltaTime;
        }

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
    void FixedUpdate()
    {
        // player input
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        //moving player
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    public void TakeDamage(int dmgAmount)
    {
        camera.Shake();
        health--;
        
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            loseScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
    
}
