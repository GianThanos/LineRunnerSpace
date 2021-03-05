using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float moveSpeedShield;
    public int scoreVar;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += Vector3.left * moveSpeedShield * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }

        scoreVar = GameManager.score;
        if (scoreVar >= 1000)
        {
            moveSpeedShield = 50;
        }
        else if (scoreVar >= 900)
        {
            moveSpeedShield = 48;
        }
        else if (scoreVar >= 800)
        {
            moveSpeedShield = 45;
        }
        else if (scoreVar >= 700)
        {
            moveSpeedShield = 40;
        }
        else if (scoreVar >= 600)
        {
            moveSpeedShield = 35;
        }
        else if (scoreVar >= 500)
        {
            moveSpeedShield = 30;
        }
        else if (scoreVar >= 400)
        {
            moveSpeedShield = 25;
        }
        else if (scoreVar >= 300)
        {
            moveSpeedShield = 20;
        }
        else if (scoreVar >= 200)
        {
            moveSpeedShield = 15;
        }
        else if (scoreVar >= 100)
        {
            moveSpeedShield = 12;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}

