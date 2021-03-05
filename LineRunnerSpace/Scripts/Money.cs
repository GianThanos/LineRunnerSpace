using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public float moveSpeedMoney;
    public int scoreVar;


    
    
    


    void Start()
    {

    }


    void Update()
    {
        transform.position += Vector3.left * moveSpeedMoney * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }

        scoreVar = GameManager.score;
        if (scoreVar >= 1000)
        {
            moveSpeedMoney = 50;
        }
        else if (scoreVar >= 900)
        {
            moveSpeedMoney = 48;
        }
        else if (scoreVar >= 800)
        {
            moveSpeedMoney = 45;
        }
        else if (scoreVar >= 700)
        {
            moveSpeedMoney = 40;
        }
        else if (scoreVar >= 600)
        {
            moveSpeedMoney = 35;
        }
        else if (scoreVar >= 500)
        {
            moveSpeedMoney = 30;
        }
        else if (scoreVar >= 400)
        {
            moveSpeedMoney = 25;
        }
        else if (scoreVar >= 300)
        {
            moveSpeedMoney = 20;
        }
        else if (scoreVar >= 200)
        {
            moveSpeedMoney = 15;
        }
        else if (scoreVar >= 100)
        {
            moveSpeedMoney = 12;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"  )
        {             
            Destroy(gameObject);
        }
  
    }
}
