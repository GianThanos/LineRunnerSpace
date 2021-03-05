using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerYPos;
    public GameObject trail;
    public AudioClip audioSwap;
    public AudioClip audioCoin;
    public AudioClip audioObstacle;
    public AudioClip audioLife;
    public AudioClip audiolvlup;
    public bool shieldIsActive;




    // Start is called before the first frame update
    void Start()
    {
        playerYPos = transform.position.y;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            //if (!trail.activeInHierarchy)
            //{
            //    trail.SetActive(true);
           // }
           //

            if (Input.GetMouseButtonDown(0))
            {
                PositionSwitch();
            }
        }
        
    }

    void PositionSwitch()
    {
        playerYPos = -playerYPos;

        transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);

        GetComponent<AudioSource>().clip = audioSwap;
        GetComponent<AudioSource>().Play();
        GameManager.instance.UpdateScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shieldIsActive == false)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                GameManager.instance.UpdateLives();

                GameManager.instance.Shake();

                GetComponent<AudioSource>().clip = audioObstacle;
                GetComponent<AudioSource>().Play();
            }
            else if (collision.gameObject.tag == "Money")
            {
                GameManager.instance.coinUpdate();

                GetComponent<AudioSource>().clip = audioCoin;
                GetComponent<AudioSource>().Play();
            }
            else if (collision.gameObject.tag == "lifeUp")
            {
                GameManager.instance.lifeUpPowerUp();

                GetComponent<AudioSource>().clip = audiolvlup;
                GetComponent<AudioSource>().Play();
            }
            else if (collision.gameObject.tag == "shield")
            {
                GameManager.instance.ShieldActivated();

                GetComponent<AudioSource>().clip = audioLife;
                GetComponent<AudioSource>().Play();
            }

        }
        else
        {
            if (collision.gameObject.tag == "Money")
            {
                GameManager.instance.coinUpdate();

                GetComponent<AudioSource>().clip = audioCoin;
                GetComponent<AudioSource>().Play();
            }
            else if (collision.gameObject.tag == "lifeUp")
            {
                GameManager.instance.lifeUpPowerUp();

                GetComponent<AudioSource>().clip = audioLife;
                GetComponent<AudioSource>().Play();
            }
            else if (collision.gameObject.tag == "shield")
            {
                GameManager.instance.ShieldActivated();

                GetComponent<AudioSource>().clip = audioLife;
                GetComponent<AudioSource>().Play();
            }

        }
    }
}
