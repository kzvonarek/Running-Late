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
