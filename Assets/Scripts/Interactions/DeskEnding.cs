using UnityEngine;

public class DeskEnding : MonoBehaviour
{
    // get fake interview building check from GameManager.cs
    private GameManager gMscript;

    void Start()
    {
        // get game manager script from Game Manager object
        gMscript = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gMscript.fakeIntRealization)
        {
            Debug.Log("Just in time.");
            // game ends
            // screen with best time
            // option to play again or go to menu
        }
    }
}
