using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

  

    public GameObject[] obstacles;
    Vector3 spawnPos;
    public float spawnRate;

    public int lifechangePoss = 90;
    public int moneychangePoss = 30;
    public int shieldchangePoss = 60;

    public int scoreVar;

    public bool isStarted = false;

 
    void Start()
    {
        spawnPos = transform.position;
        //StartCoroutine("SpawnObstacles");
        isStarted = false;
    }

    
    void Update()
    {
       if (isStarted == false)
        {
            isStarted = true;
            StartCoroutine("SpawnObstacles");
            print("yo");
        } 
    }




    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            GameManager.instance.UpdateScore();
            if (PlayerPrefs.GetInt("Skin") == 3)
            {
                GameManager.instance.UpdateScore();
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }

    void Spawn()
    {
        int randObstacle = Random.Range(0, obstacles.Length);

        int randSpot = Random.Range(0, 2); // 1= bottom 0 = top

        int lifechange = Random.Range(0, 100); 

        int moneychange = Random.Range(0, 100);

        int shieldchange = Random.Range(0, 100);

        spawnPos = transform.position;

        if (randSpot < 1)
        {
            if (randObstacle == 3)
            {
                if (moneychange < moneychangePoss)
                {
                    randObstacle = 2;
                }
            }
            else if (randObstacle == 4)
            {
                if (lifechange < lifechangePoss)
                {
                    randObstacle = 2;

                }
            }
            else if (randObstacle == 5)
            {
                if (shieldchange < shieldchangePoss)
                {
                    randObstacle = 2;

                }
            }

            Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
        }
        else
        {
            

            spawnPos.y = -transform.position.y;

            if (randObstacle == 1)
            {
                spawnPos.x += 1;
            }
            else if (randObstacle == 2)
            {
                spawnPos.x += 2;
            }
            else if (randObstacle == 3)
            {
                if (moneychange < moneychangePoss)
                {
                    randObstacle = 2;
                }
            }
            else if (randObstacle == 4)
            {
                if (lifechange < lifechangePoss)
                {
                    randObstacle = 2;

                }
            }

            else if (randObstacle == 5)
            {
                if (shieldchange < shieldchangePoss)
                {
                    randObstacle = 2;

                }
            }

            GameObject obs = Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 180);

        }
        scoreVar = GameManager.score;
        if (scoreVar >= 1000)
        {
            spawnRate =0.40f;
        }
        else if (scoreVar >= 900)
        {
            spawnRate = 0.42f;
        }
        else if (scoreVar >= 800)
        {
            spawnRate = 0.49f;
        }
        else if (scoreVar >= 700)
        {
            spawnRate = 0.56f;
        }
        else if (scoreVar >= 600)
        {
            spawnRate = 0.63f;
        }
        else if (scoreVar >= 500)
        {
            spawnRate = 0.7f;
        }
        else if (scoreVar >= 400)
        {
            spawnRate = 0.77f;
        }
        else if (scoreVar >= 300)
        {
            spawnRate = 0.84f;
        }
        else if (scoreVar >= 200)
        {
            spawnRate = 0.91f;
        }
        else if (scoreVar >= 100)
        {
            spawnRate = 1;
        }

    }

    public void CallCo()
    {

        if (isStarted == false)
        {
            print("callco");
            StartCoroutine("SpawnObstacles");
        }
        
    }

}
