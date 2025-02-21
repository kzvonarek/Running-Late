using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // game timer
    [SerializeField] float gameTimer;

    // timer text
    private GameObject timerTextObj;
    private TMP_Text timerText;
    private int minutes;
    private int seconds;

    // game condition
    private bool gameOver = false;

    // don't destroy on load
    private static GameManager instance;

    void Start()
    {
        FindGameTimerText();

        Application.targetFrameRate = 60;
    }

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

    void Awake()
    {
        // don't destroy on load to new scene
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnNewScene;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnNewScene;
    }

    void OnNewScene(Scene scene, LoadSceneMode mode)
    {
        FindGameTimerText(); // find the timer text object again
    }

    void FindGameTimerText()
    {
        timerTextObj = GameObject.Find("Game Timer");
        timerText = timerTextObj.GetComponentInChildren<TMP_Text>();
    }
}
