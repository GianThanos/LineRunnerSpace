using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
{

    public float moveSpeedlifeup;
    public int scoreVar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeedlifeup * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }

        scoreVar = GameManager.score;
        if (scoreVar >= 1000)
        {
            moveSpeedlifeup = 50;
        }
        else if (scoreVar >= 900)
        {
            moveSpeedlifeup = 48;
        }
        else if (scoreVar >= 800)
        {
            moveSpeedlifeup = 45;
        }
        else if (scoreVar >= 700)
        {
            moveSpeedlifeup = 40;
        }
        else if (scoreVar >= 600)
        {
            moveSpeedlifeup = 35;
        }
        else if (scoreVar >= 500)
        {
            moveSpeedlifeup = 30;
        }
        else if (scoreVar >= 400)
        {
            moveSpeedlifeup = 25;
        }
        else if (scoreVar >= 300)
        {
            moveSpeedlifeup = 20;
        }
        else if (scoreVar >= 200)
        {
            moveSpeedlifeup = 15;
        }
        else if (scoreVar >= 100)
        {
            moveSpeedlifeup = 12;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
 
    }
}
