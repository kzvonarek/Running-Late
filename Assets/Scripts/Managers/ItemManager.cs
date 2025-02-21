using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // items and placements arrays
    [SerializeField] GameObject[] items;
    [SerializeField] GameObject[] itemPlacements;

    // random index for each item
    private int[] shirtPosChoices = { 0, 5, 10 };
    private int shirtPosChoice;
    private int[] pantsPosChoices = { 1, 6, 11 };
    private int pantsPosChoice;
    private int[] shoesPosChoices = { 2, 7, 12 };
    private int shoesPosChoice;
    private int[] watchPosChoices = { 3, 8, 13 };
    private int watchPosChoice;
    private int[] duckyPosChoices = { 4, 9, 14 };
    private int duckyPosChoice;

    void Start()
    {
        // get random itemPlacements index for each collectable item
        shirtPosChoice = GetRandomPosChoice(shirtPosChoices);
        pantsPosChoice = GetRandomPosChoice(pantsPosChoices);
        shoesPosChoice = GetRandomPosChoice(shoesPosChoices);
        watchPosChoice = GetRandomPosChoice(watchPosChoices);
        duckyPosChoice = GetRandomPosChoice(duckyPosChoices);

        // move items to respective position in itemPlacments
        items[0].transform.position = itemPlacements[shirtPosChoice].transform.position;
        items[1].transform.position = itemPlacements[pantsPosChoice].transform.position;
        items[2].transform.position = itemPlacements[shoesPosChoice].transform.position;
        items[3].transform.position = itemPlacements[watchPosChoice].transform.position;
        items[4].transform.position = itemPlacements[duckyPosChoice].transform.position;
    }

    int GetRandomPosChoice(int[] posChoices)
    {
        return posChoices[Random.Range(0, posChoices.Length)];
    }
}
