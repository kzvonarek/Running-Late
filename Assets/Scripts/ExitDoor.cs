using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    // item collection check [House Scene]
    private bool allItemsCollected = false;
    [SerializeField] Toggle[] itemToggles;

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
            // go from house to city
            if (SceneManager.GetActiveScene().name == "House" && allItemsCollected)
            {
                SceneManager.LoadScene("City");
            }
            else if (SceneManager.GetActiveScene().name == "House" && !allItemsCollected)
            {
                // TODO: add speech bubble saying this
                Debug.Log("I don't have everything yet");
            }

            // add more if statements for other exit/entrance doors
        }
    }
}
