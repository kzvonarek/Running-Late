using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // game timer
    [SerializeField] float gameTimer;
    [SerializeField] TMP_Text timerText;
    private int minutes;
    private int seconds;
    private bool gameOver = false;

    void Update()
    {
        // reduce game timer by 1 second intervals
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }
        else
        {
            gameTimer = 0f;
            gameOver = true;
        }

        // game over functionality
        if (gameOver == true)
        {
            Debug.Log("Out Of Time.");
        }

        // update timer text to minutes and seconds on screen
        minutes = Mathf.FloorToInt(gameTimer / 60);
        seconds = Mathf.FloorToInt(gameTimer % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
