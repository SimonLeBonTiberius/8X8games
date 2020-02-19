using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static GameManager Instance;
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameover;
    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject gamePage;
    public GameObject boardGame;
    int score = 0;


    enum PageState
    {
        Start,
        GameOver,
        Game,
        GameOverForTime

    }





    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        SetPageState(PageState.Start);
        BoardScript.OnEndGame += OnEndGame;
        BoardScript.OnScored += OnScored;
    }
    void OnDisable()
    {

        BoardScript.OnEndGame -= OnEndGame;
        BoardScript.OnScored -= OnScored;
    }
    void OnEndGame()
    {
        SetPageState(PageState.GameOver);


    }
    void OnScored()
    {
        score = PlayerPrefs.GetInt("Score");
        ScorePointScript scorepointscript = gamePage.GetComponentInChildren<ScorePointScript>();
        scorepointscript.punteggio = score;
        ScorePointScript scorepointscriptover = gameOverPage.GetComponentInChildren<ScorePointScript>();
        scorepointscriptover.punteggio = score;
        int highscore = PlayerPrefs.GetInt("HighScore");
        if (score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
           
        }



    }
    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.Game:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                gamePage.SetActive(true);
                boardGame.SetActive(true);
                break;

            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                gamePage.SetActive(false);
                boardGame.SetActive(false);
                break;

            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                gamePage.SetActive(false);
                boardGame.SetActive(false);
                break;


        }
    }
    public void ConfirmGameOver()
    {
        SetPageState(PageState.Start);



    }
    public void StartGame()
    {
        SetPageState(PageState.Game);
        ScorePointScript scorepointscript = gamePage.GetComponentInChildren<ScorePointScript>();
        scorepointscript.punteggio = 0;



    }
}
