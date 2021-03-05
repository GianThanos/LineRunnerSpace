using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool gameStarted = false;
    public GameObject player;
    public int lives = 2;
    public static int score = 0;
    public Text scoreText;
    public Text livesText;
    public GameObject menuUI;
    public GameObject GamePlayUI;
    public GameObject spawner;
    public GameObject backgroundParticle;
    Vector3 originalCamPos;
    public Text highscore;
    public GameObject newHighscore;

    int coin = 0;
    public Text CoinText;

    public int TotalCoins;

    public Text allthecoins;

    public GameObject BackShopButton;
    public GameObject line;

    public GameObject BuyRedButton;
    public GameObject EquipRedButton;
    public GameObject EquipedRed;
    public GameObject RedTrail;
    public GameObject playerWhiteTrail;
    public GameObject playerRedTrail;
    public GameObject shopRedModel;

    public int redtrailCost = 10;

    public int selectedSkin;
    public int redBought;
    public Text totalcoinintheshop;
    public GameObject totalShop;
    //
    public int purpletrailCost = 10;
    public GameObject BuyPurpleButton;
    public GameObject EquipPurpleButton;
    public GameObject EquipedPurple;
    public GameObject PurpleTrail;
    public GameObject playerPurpleTrail;
    public GameObject shopPurpleModel;
    public int purpleBought;

    public int greentrailCost = 10;
    public GameObject BuyGreenButton;
    public GameObject EquipGreenButton;
    public GameObject EquipedGreen;
    public GameObject GreenTrail;
    public GameObject playerGreenTrail;
    public GameObject shopGreenModel;
    public int greenBought;

    public GameObject EquipWhiteButton;
    public GameObject EquipedWhite;

    public GameObject shopWhiteModel;



    public GameObject Continue;
    public GameObject YesToAd;
    public GameObject NoToAd;
    public int hadWatchaAd = 0;

    public ObstacleSpawner other;

    public int tempScore;

    public int shieldDuration = 5;

    public GameObject Shield;

    public PlayerController pc;
    



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        originalCamPos = Camera.main.transform.position;
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        allthecoins.text = "Gold : " + PlayerPrefs.GetInt("Coins", 0).ToString();
        selectedSkin = PlayerPrefs.GetInt("Skin");
        redBought = PlayerPrefs.GetInt("redIsBought", 0);
        totalcoinintheshop.text = "Gold : " + PlayerPrefs.GetInt("Coins", 0).ToString();

        purpleBought = PlayerPrefs.GetInt("purpleIsBought", 0);

        greenBought = PlayerPrefs.GetInt("greenIsBought", 0);


        if (PlayerPrefs.GetInt("Skin") == 0)
        {
            playerWhiteTrail.SetActive(true);
            playerRedTrail.SetActive(false);
            playerPurpleTrail.SetActive(false);
            playerGreenTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin") == 1)
        {
            playerRedTrail.SetActive(true);
            playerWhiteTrail.SetActive(false);
            playerPurpleTrail.SetActive(false);
            playerGreenTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin") == 2)
        {
            playerRedTrail.SetActive(false);
            playerWhiteTrail.SetActive(false);
            playerPurpleTrail.SetActive(true);
            playerGreenTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin") == 3)
        {
            playerRedTrail.SetActive(false);
            playerWhiteTrail.SetActive(false);
            playerPurpleTrail.SetActive(false);
            playerGreenTrail.SetActive(true);
        }

    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        GamePlayUI.SetActive(true);
        spawner.SetActive(true);
        backgroundParticle.SetActive(true);
        hadWatchaAd = 0;
        if (PlayerPrefs.GetInt("Skin") == 1)
        {
            lives = 4;
            livesText.text = " Lives : " + lives;
        }

    }

    public void GameOver()
    {
        player.SetActive(false);
        Continue.SetActive(false);
        YesToAd.SetActive(false);
        NoToAd.SetActive(false);

        TotalCoins = PlayerPrefs.GetInt("Coins", 0) + coin;
        allthecoins.text = "Gold :" + TotalCoins.ToString();
        PlayerPrefs.SetInt("Coins", TotalCoins);


        Invoke("ReloadLevel", 1.5f);
        score = 0;


    }

    public void ReloadLevel()
    {

        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if (lives <= 0)
        {
            if (hadWatchaAd == 0)
            {
                tempScore = score;
                player.SetActive(false);

                Continue.SetActive(true);
                YesToAd.SetActive(true);
                NoToAd.SetActive(true);

            }
            else if (hadWatchaAd == 1)
            {
                GameOver();
            }



        }
        else
        {
            lives--;
            livesText.text = " Lives : " + lives;
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = " Score : " + score;
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            newHighscore.SetActive(true);

            PlayerPrefs.SetInt("Highscore", score);
            highscore.text = score.ToString();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Shake()
    {
        StartCoroutine("CameraShake");
    }



    IEnumerator CameraShake()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }


    public void coinUpdate()
    {
        coin++;
        if (PlayerPrefs.GetInt("Skin") == 2)
        {
            coin++;
        }
        CoinText.text = "Gold : " + coin.ToString();

    }

    public void lifeUpPowerUp()
    {
        lives++;
        livesText.text = " Lives : " + lives;
    }

    public void ShopEntry()
    {
        backgroundParticle.SetActive(true);
        player.SetActive(false);
        line.SetActive(false);
        menuUI.SetActive(false);
        BackShopButton.SetActive(true);
        shopRedModel.SetActive(true);
        totalShop.SetActive(true);

        shopPurpleModel.SetActive(true);
        shopGreenModel.SetActive(true);
        shopWhiteModel.SetActive(true);



        if (PlayerPrefs.GetInt("redIsBought") == 1)
        {
            EquipRedButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("redIsBought") == 0)
        {
            RedTrail.SetActive(true);
        }


        if (PlayerPrefs.GetInt("purpleIsBought") == 1)
        {
            EquipPurpleButton.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("purpleIsBought") == 0)
        {
            PurpleTrail.SetActive(true);
        }


        if (PlayerPrefs.GetInt("greenIsBought") == 1)
        {
            EquipGreenButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("greenIsBought") == 0)
        {
            GreenTrail.SetActive(true);
        }

        EquipWhiteButton.SetActive(true);


        if (PlayerPrefs.GetInt("Skin") == 1)
        {
            EquipRedButton.SetActive(false);
            EquipedRed.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Skin") == 2)
        {
            EquipPurpleButton.SetActive(false);
            EquipedPurple.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Skin") == 3)
        {
            EquipGreenButton.SetActive(false);
            EquipedGreen.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Skin") == 0)
        {
            EquipWhiteButton.SetActive(false);
            EquipedWhite.SetActive(true);
        }



    }

    public void ShopExit()
    {
        backgroundParticle.SetActive(false);
        player.SetActive(true);
        line.SetActive(true);
        menuUI.SetActive(true);
        BackShopButton.SetActive(false);
        RedTrail.SetActive(false);
        shopRedModel.SetActive(false);
        EquipedRed.SetActive(false);
        totalShop.SetActive(false);

        PurpleTrail.SetActive(false);
        shopPurpleModel.SetActive(false);
        EquipedPurple.SetActive(false);

        GreenTrail.SetActive(false);
        shopGreenModel.SetActive(false);
        EquipedGreen.SetActive(false);

        //playerWhiteTrail.SetActive(false);
        shopWhiteModel.SetActive(false);
        EquipedWhite.SetActive(false);

        EquipPurpleButton.SetActive(false);
        EquipGreenButton.SetActive(false);
        EquipRedButton.SetActive(false);
        EquipWhiteButton.SetActive(false);


    }

    public void BuyRed()
    {
        if (PlayerPrefs.GetInt("Coins") >= redtrailCost)
        {
            BuyRedButton.SetActive(false);
            EquipRedButton.SetActive(true);
            int temp = (PlayerPrefs.GetInt("Coins") - redtrailCost);
            PlayerPrefs.SetInt("Coins", temp);
            allthecoins.text = "Coins :" + (PlayerPrefs.GetInt("Coins").ToString());
            PlayerPrefs.SetInt("redIsBought", 1);
            totalcoinintheshop.text = "Gold :" + (PlayerPrefs.GetInt("Coins").ToString());

        }
    }

    public void EquipRed()
    {
        if (PlayerPrefs.GetInt("purpleIsBought") == 1)
        {
            EquipPurpleButton.SetActive(true);
            EquipedPurple.SetActive(false);
            PurpleTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("purpleIsBought") == 0)
        {
            EquipPurpleButton.SetActive(false);
            EquipedPurple.SetActive(false);
            PurpleTrail.SetActive(true);
        }


        if (PlayerPrefs.GetInt("greenIsBought") == 1)
        {
            EquipGreenButton.SetActive(true);
            EquipedGreen.SetActive(false);
            GreenTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("greenIsBought") == 0)
        {
            EquipGreenButton.SetActive(false);
            EquipedGreen.SetActive(false);
            GreenTrail.SetActive(true);
        }
        

        EquipWhiteButton.SetActive(true);
        EquipedWhite.SetActive(false);



        EquipRedButton.SetActive(false);
        EquipedRed.SetActive(true);
        playerWhiteTrail.SetActive(false);
        playerRedTrail.SetActive(true);
        playerPurpleTrail.SetActive(false);
        playerGreenTrail.SetActive(false);
        int temp2 = 1;
        PlayerPrefs.SetInt("Skin", temp2);


    }

    public void BuyPurple()
    {
        if (PlayerPrefs.GetInt("Coins") >= purpletrailCost)
        {
            BuyPurpleButton.SetActive(false);
            EquipPurpleButton.SetActive(true);
            int temp3 = (PlayerPrefs.GetInt("Coins") - purpletrailCost);
            PlayerPrefs.SetInt("Coins", temp3);
            allthecoins.text = "Gold :" + (PlayerPrefs.GetInt("Coins").ToString());
            PlayerPrefs.SetInt("purpleIsBought", 1);
            totalcoinintheshop.text = "Gold :" + (PlayerPrefs.GetInt("Coins").ToString());

        }
    }

    public void EquipPurple()
    {

        if (PlayerPrefs.GetInt("greenIsBought") == 1)
        {
            EquipGreenButton.SetActive(true);
            EquipedGreen.SetActive(false);
            GreenTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("greenIsBought") == 0)
        {
            EquipGreenButton.SetActive(false);
            EquipedGreen.SetActive(false);
            GreenTrail.SetActive(true);
        }

        if (PlayerPrefs.GetInt("redIsBought") == 1)
        {
            EquipRedButton.SetActive(true);
            EquipedRed.SetActive(false);
            RedTrail.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("redIsBought") == 0)
        {
            EquipRedButton.SetActive(false);
            EquipedRed.SetActive(false);
            RedTrail.SetActive(true);
        }

        EquipWhiteButton.SetActive(true);
        EquipedWhite.SetActive(false);



        EquipPurpleButton.SetActive(false);
        EquipedPurple.SetActive(true);
        playerWhiteTrail.SetActive(false);
        playerRedTrail.SetActive(false);
        playerPurpleTrail.SetActive(true);
        playerGreenTrail.SetActive(false);
        int temp4 = 2;
        PlayerPrefs.SetInt("Skin", temp4);
    }


    public void BuyGreen()
    {
        if (PlayerPrefs.GetInt("Coins") >= greentrailCost)
        {
            BuyGreenButton.SetActive(false);
            EquipGreenButton.SetActive(true);
            int temp5 = (PlayerPrefs.GetInt("Coins") - greentrailCost);
            PlayerPrefs.SetInt("Coins", temp5);
            allthecoins.text = "Gold :" + (PlayerPrefs.GetInt("Coins").ToString());
            PlayerPrefs.SetInt("greenIsBought", 1);
            totalcoinintheshop.text = "Gold :" + (PlayerPrefs.GetInt("Coins").ToString());

        }
    }

    public void EquipGreen()
    {
        if (PlayerPrefs.GetInt("purpleIsBought") == 1)
        {
            EquipPurpleButton.SetActive(true);
            EquipedPurple.SetActive(false);
            PurpleTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("purpleIsBought") == 0)
        {
            EquipPurpleButton.SetActive(false);
            EquipedPurple.SetActive(false);
            PurpleTrail.SetActive(true);
        }

        if (PlayerPrefs.GetInt("redIsBought") == 1)
        {
            EquipRedButton.SetActive(true);
            EquipedRed.SetActive(false);
            RedTrail.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("redIsBought") == 0)
        {
            EquipRedButton.SetActive(false);
            EquipedRed.SetActive(false);
            RedTrail.SetActive(true);
        }


        EquipWhiteButton.SetActive(true);
        EquipedWhite.SetActive(false);

        

        EquipGreenButton.SetActive(false);
        EquipedGreen.SetActive(true);
        playerWhiteTrail.SetActive(false);
        playerRedTrail.SetActive(false);
        playerPurpleTrail.SetActive(false);
        playerGreenTrail.SetActive(true);
        int temp6 = 3;
        PlayerPrefs.SetInt("Skin", temp6);
    }

    public void EquipWhite()
    {
        if (PlayerPrefs.GetInt("purpleIsBought") == 1)
        {
            EquipPurpleButton.SetActive(true);
            EquipedPurple.SetActive(false);
            PurpleTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("purpleIsBought") == 0)
        {
            EquipPurpleButton.SetActive(false);
            EquipedPurple.SetActive(false);
            PurpleTrail.SetActive(true);
        }


        if (PlayerPrefs.GetInt("greenIsBought") == 1)
        {
            EquipGreenButton.SetActive(true);
            EquipedGreen.SetActive(false);
            GreenTrail.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("greenIsBought") == 0)
        {
            EquipGreenButton.SetActive(false);
            EquipedGreen.SetActive(false);
            GreenTrail.SetActive(true);
        }

        if (PlayerPrefs.GetInt("redIsBought") == 1)
        {
            EquipRedButton.SetActive(true);
            EquipedRed.SetActive(false);
            RedTrail.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("redIsBought") == 0)
        {
            EquipRedButton.SetActive(false);
            EquipedRed.SetActive(false);
            RedTrail.SetActive(true);
        }

 

 

        EquipWhiteButton.SetActive(false);
        EquipedWhite.SetActive(true);


        playerWhiteTrail.SetActive(true);
        playerRedTrail.SetActive(false);
        playerPurpleTrail.SetActive(false);
        playerGreenTrail.SetActive(false);
        int temp7 = 0;
        PlayerPrefs.SetInt("Skin", temp7);
    }

    public void AdRoutine()
    {



        Continue.SetActive(false);
        YesToAd.SetActive(false);
        NoToAd.SetActive(false);

        hadWatchaAd = 1;

        spawner.SetActive(true);
        other.CallCo();


    }

    public void ShieldActivated()
    {
        StartCoroutine("ShieldActive");
    }

    IEnumerator ShieldActive()
    {
        Shield.SetActive(true);
        pc.shieldIsActive = true;

        yield return new WaitForSeconds(shieldDuration);

        Shield.SetActive(false);
        pc.shieldIsActive = false;
    }
}