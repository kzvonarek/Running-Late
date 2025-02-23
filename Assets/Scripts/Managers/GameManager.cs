using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // player
    private GameObject player;

    // game timer
    [SerializeField] float gameTimer;

    // timer text
    private GameObject timerTextObj;
    private TMP_Text timerText;
    private int minutes;
    private int seconds;
    private int milliseconds;

    // pause menu
    [SerializeField] GameObject pauseMenu;
    private bool paused;

    // game condition
    private bool gameOver = false;

    // don't destroy on load
    private static GameManager instance;

    // ExitDoor.cs - fake interview visited/realization check [Fake Interview Building Scene]
    [HideInInspector] public bool fakeIntRealization;

    void Start()
    {
        FindGameTimerText();
        FindPlayer();
        Application.targetFrameRate = 60;
        Time.timeScale = 1;

        // // for testing
        // fakeIntRealization = true;
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
        milliseconds = Mathf.FloorToInt(gameTimer * 100 % 100);
        timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);

        // pause game when player presses escape or presses pause button
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true) // unpause game
        {
            unpauseGame();
        }
    }

    public void pauseGame()
    {
        paused = true;
        pauseMenu.SetActive(true); // make pause menu visible
        Time.timeScale = 0;
    }

    public void unpauseGame()
    {
        paused = false;
        pauseMenu.SetActive(false); // make pause menu invisible
        Time.timeScale = 1;
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
        FindPlayer(); // find player again

        if (SceneManager.GetActiveScene().name == "City" && fakeIntRealization)
        {
            player.transform.position = new Vector2(GameObject.Find("Fake Interview Door").transform.position.x,
                                            GameObject.Find("Fake Interview Door").transform.position.y - 0.75f);
        }
    }

    void FindGameTimerText()
    {
        timerTextObj = GameObject.Find("Game Timer");
        timerText = timerTextObj.GetComponentInChildren<TMP_Text>();
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
