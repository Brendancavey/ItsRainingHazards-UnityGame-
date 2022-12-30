using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            ScoreManager.instance.ChangeScore(coinValue);
            Destroy(gameObject);
        }
    }
}
