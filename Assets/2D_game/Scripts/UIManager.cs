using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] LifeImages = null;
    [SerializeField] private Image lifeDisplay = null;

    private int score = 0;
    private int highScore = 0;
    private string highScoreDate = "";

    [SerializeField] private Text scoreDisplay = null;
    [SerializeField] private Text highScoreDisplay = null;

    [SerializeField] private GameObject highScoreText = null;

    [SerializeField] private GameObject TitleScreen = null;

    [SerializeField] private GameObject gameOverScreen = null;

    [SerializeField] private GameObject Paused = null;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreDate = PlayerPrefs.GetString("HighScoreDate", "");
        highScoreDisplay.text = "High: " + highScore + " " + highScoreDate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int count)
    {
        lifeDisplay.sprite = LifeImages[count];
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreDisplay.text = "Score: " + score;
        CheckForHighScore();
    }

    public void HideTitleScreen()
    {
        score = 0;
        scoreDisplay.text = "Score: " + score;
        TitleScreen.SetActive(false);
    }
    
    public void ShowTitleScreen()
    {
        TitleScreen.SetActive(true);
    }

    public void HideGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void HidePauseScreen()
    {
        Paused.SetActive(false);
    }

    public void ShowPauseScreen()
    {
        Paused.SetActive(true);
    }

    public void HideHighScore()
    {
        highScoreText.SetActive(false);
    }

    public void ShowHighScore()
    {
        highScoreText.SetActive(true);
    }

    public void CheckForHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreDisplay.text = "High: " + highScore + " " + System.DateTime.Today.ToString("M/dd/y");
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.SetString("HighScoreDate", System.DateTime.Today.ToString("M/dd/y"));
        }
    }
}
