using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{

    string GameID = "3629989";
    string placementID = "rewardedVideo";
    public ObstacleSpawner ObsSpawner;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GameID);
        Advertisement.AddListener(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAds()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(placementID))
        {
            Advertisement.Show(placementID);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
        GameManager.instance.GameOver();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            GameManager.instance.lives = 1;
            //reward player
            GameManager.instance.lifeUpPowerUp();
            GameManager.instance.player.SetActive(true);
            GameManager.score = GameManager.instance.tempScore;
            GameManager.instance.scoreText.text = " Score : " + GameManager.score;
            GameManager.instance.ShieldActivated();


        }
        else
        {
            GameManager.instance.GameOver();
        }
    }
}
