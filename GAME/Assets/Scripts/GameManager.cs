using UnityEngine;
using TMPro;
using System;
//using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour /*IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener*/
{
    public static GameManager Instance; 
    int score;
    int highScore;
    [Header("Score UI labels")]
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;

    [Header("Game over panel labels")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI gameOverScoreTxt;
    [SerializeField] TextMeshProUGUI gameOverHighScoreTxt;
    public static event Action OnGameRestart;

    //[Header("Unity Ad`s ID")]
    //string _gameId;
    //[SerializeField] string _iOSGameId;
    //[SerializeField] string _androidGameId;
    //string _adUnitId = "VideoAD";


    private void Awake()
    {
        Instance = this;
        //InitializeAds();
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text = "Best :" + highScore.ToString();
        gameOverPanel.gameObject.SetActive(false);
    }
    #region Unity ads initialization
    //public void InitializeAds()
    //{
    //    _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
    //        ? _iOSGameId
    //        : _androidGameId;
    //    Advertisement.Initialize(_gameId, true, this);
    //}
    //public void OnInitializationComplete()
    //{
    //    Debug.Log("Unity Ads initialization complete.");
    //    LoadAd();
    //}
    //public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    //{
    //    Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    //}
    //#endregion
    //#region Implement Load Listener and Show Listener interface methods
    //public void LoadAd()
    //{
    //    Advertisement.Load(_adUnitId, this);
    //}
    //public void ShowAd()
    //{
    //    Advertisement.Show(_adUnitId, this);
    //}
    //public void OnUnityAdsAdLoaded(string adUnitId)
    //{

    //}

    //public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    //{
    //    Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");

    //}

    //public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    //{
    //    Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    //}

    //public void OnUnityAdsShowStart(string adUnitId) { }
    //public void OnUnityAdsShowClick(string adUnitId) { }
    //public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }
    #endregion
    public void IncreeseScore(int addedScore)
    {
        score += addedScore;
        UpdateScoreText();

        if (highScore < score)
        {
            SetHighScore();
        }
    }
    private void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", score);
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text ="Best :" + highScore.ToString();
    }
    public void EndGame()
    {
        //ShowAd();
        Time.timeScale = 0;
        gameOverPanel.gameObject.SetActive(true);
        gameOverScoreTxt.text = "Score: " + score.ToString();
        gameOverHighScoreTxt.text = "Highscore: "+ highScore.ToString();
    }
    private void UpdateScoreText()
    {
        scoreTxt.text = score.ToString();
    }
    public void RestartGame()
    {
        OnGameRestart?.Invoke();
        score = 0;
        UpdateScoreText();
        gameOverPanel.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
