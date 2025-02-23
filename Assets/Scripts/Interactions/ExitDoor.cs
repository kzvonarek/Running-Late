using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    // item collection check [House Scene]
    private bool allItemsCollected = false;
    [SerializeField] Toggle[] itemToggles;

    // get fake interview building check from GameManager.cs
    private GameManager gMscript;

    // door type bool
    [SerializeField] bool isFakeIntDoor;
    [SerializeField] bool isIntDoor;

    void Start()
    {
        // get game manager script from Game Manager object
        gMscript = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        // item collection check [House Scene]
        if (SceneManager.GetActiveScene().name == "House")
        {
            if (itemToggles[0].isOn && itemToggles[1].isOn && itemToggles[2].isOn
            && itemToggles[3].isOn && itemToggles[4].isOn)
            {
                allItemsCollected = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // go from house to city (make sure items collected first)
            if (SceneManager.GetActiveScene().name == "House" && allItemsCollected)
            {
                SceneManager.LoadScene("City");
            }
            else if (SceneManager.GetActiveScene().name == "House" && !allItemsCollected)
            {
                // TODO: add speech bubble saying this
                Debug.Log("I don't have everything yet!");
            }

            // go from city to fake interview building (don't allow re-entry)
            if (SceneManager.GetActiveScene().name == "City" && !gMscript.fakeIntRealization && isFakeIntDoor)
            {
                SceneManager.LoadScene("Fake Interview Building");
            }
            else if (SceneManager.GetActiveScene().name == "City" && gMscript.fakeIntRealization && isFakeIntDoor)
            {
                // TODO: add speech bubble saying this
                Debug.Log("I already went here!");
            }

            // go from city to actual interview building
            if (SceneManager.GetActiveScene().name == "City" && gMscript.fakeIntRealization && isIntDoor)
            {
                SceneManager.LoadScene("Interview Building");
            }
            else if (SceneManager.GetActiveScene().name == "City" && !gMscript.fakeIntRealization && isIntDoor)
            {
                // TODO: add speech bubble saying this
                Debug.Log("Wrong building!");
            }

            // go from fake interview building to city (don't let leave until condition met)
            if (SceneManager.GetActiveScene().name == "Fake Interview Building" && gMscript.fakeIntRealization)
            {
                SceneManager.LoadScene("City");
            }
            else if (SceneManager.GetActiveScene().name == "Fake Interview Building" && !gMscript.fakeIntRealization)
            {
                // TODO: add speech bubble saying this
                Debug.Log("I have to get to the interview!");
            }
        }
    }
}
