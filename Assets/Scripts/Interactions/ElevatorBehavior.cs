using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    private bool elevatorFixed = false;

    // get fake interview realization check from GameManager.cs
    private GameManager gMscript;

    void Start()
    {
        // get game manager script from Game Manager object
        gMscript = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // fix elevator if not fixed yet
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)
            && !elevatorFixed && !gMscript.fakeIntRealization)
        {
            // TODO: add the puzzle
            Debug.Log("Start Elevator Fix Puzzle");
        }

        // enter elevator once fixed, and have not realized fake interview yet
        else if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)
            && elevatorFixed && !gMscript.fakeIntRealization)
        {
            Debug.Log("Enter Elevator");
        }

        // prevent entering elevator once fixed, b/c have not realized fake interview yet
        else if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)
            && elevatorFixed && gMscript.fakeIntRealization)
        {
            Debug.Log("I have to get to the other interview!");
        }
    }
}
