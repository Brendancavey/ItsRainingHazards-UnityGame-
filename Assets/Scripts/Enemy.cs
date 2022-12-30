using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    public float speed;

    Player playerScript;

    public int damage;

    public GameObject OnDeathExplosion;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //setting fall down speed
        speed = Random.Range(minSpeed, maxSpeed) * playerScript.difficultyScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemy falling from sky
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if(hitObject.tag == "Player")
        {
            print("We hit the player");
            playerScript.TakeDamage(damage);
            print(playerScript.health);
            EnemyDeath();


        }

        if (hitObject.tag == "Ground")
        {
            EnemyDeath();
        }
        if (hitObject)
        {

        }
    }
    void EnemyDeath()
    {
        Destroy(gameObject);
        Instantiate(OnDeathExplosion, transform.position, Quaternion.identity);
    }
}
