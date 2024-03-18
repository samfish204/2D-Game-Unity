using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public bool gameStarted = false;
    [SerializeField] private GameObject Player = null;
    private UIManager UI = null;
    public bool paused = false;
        
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Player, new Vector3(-6.0f, 0.5f, 0), Quaternion.identity);

            gameOver = false;
            gameStarted = true;

            UI.HideTitleScreen();
            UI.ShowHighScore();
        }

        if (gameStarted && gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            // yield return new WaitForSeconds(3.0f);
            UI.HideGameOverScreen();
            UI.HideHighScore();
            UI.ShowTitleScreen();
            gameStarted = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused == false)
            {
                Time.timeScale = 0;
                paused = true;
                UI.ShowPauseScreen();
            } else
            {
                Time.timeScale = 1;
                paused = false;
                UI.HidePauseScreen();
            }
        }
    }
}
