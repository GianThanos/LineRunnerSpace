using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float moveSpeedObstacle;
    public int scoreVar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);


        transform.position += Vector3.left * moveSpeedObstacle * Time.deltaTime;

        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }

        scoreVar = GameManager.score;
        if (scoreVar >= 1000)
        {
            moveSpeedObstacle = 50;
        }
        else if (scoreVar >= 900)
        {
            moveSpeedObstacle = 48;
        }
        else if (scoreVar >= 800)
        {
            moveSpeedObstacle = 45;
        }
        else if (scoreVar >= 700)
        {
            moveSpeedObstacle = 40;
        }
        else if (scoreVar >= 600)
        {
            moveSpeedObstacle = 35;
        }
        else if (scoreVar >= 500)
        {
            moveSpeedObstacle = 30;
        }
        else if (scoreVar >= 400)
        {
            moveSpeedObstacle = 25;
        }
        else if (scoreVar >= 300)
        {
            moveSpeedObstacle = 20;
        }
        else if (scoreVar >= 200)
        {
            moveSpeedObstacle = 15;
        }
        else if (scoreVar >= 100)
        {
            moveSpeedObstacle = 12;
        }
    }   

}
