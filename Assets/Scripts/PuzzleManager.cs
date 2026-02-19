using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class PuzzleManager : MonoBehaviour
{
    private int puzzleNumber;
    [Header("puzzle 1")]
    [SerializeField] private List<HallwayPaintingInteraction> hallways = new List<HallwayPaintingInteraction>();
    [SerializeField] GameObject hallway1;

    [Header("puzzle 2")]
    [SerializeField] GameObject hallway1Replacement;
    [SerializeField] GameObject wardrobe;

    [SerializeField] Puzzle2Trigger p2Trigger;

    [Header("puzzle 3")]
    [SerializeField] private List<GameObject> hallwaysStairs = new List<GameObject>();
    [SerializeField] GameObject key1;
    [SerializeField] GameObject key2;

    [Header("Header 3")]

    [SerializeField] GameObject door;
    void Start()
    {
        puzzleNumber = 1;

        foreach(var stairs in hallwaysStairs)
        {
            stairs.SetActive(false);
        }
        key1.SetActive(false);
        key2.SetActive(false);
    }

    void Update()
    {
        if (puzzleNumber == 1 && AllHallwaysMatch())
        {
            UnityEngine.Debug.Log("first puzzle completed!");
            DisableAllTriggers();
            puzzleNumber++;
            generateSecondPuzzle();
        }
        else if(puzzleNumber==2 && p2Trigger.touchedWardRobe == true)
        {
            puzzleNumber++;
            generateThirdPuzzle();
        }
    }

    private bool AllHallwaysMatch()
    {
        if (hallways == null || hallways.Count == 0) return false;

        foreach (var h in hallways)
        {
            if (h == null) return false;
            if (h.hallwayColor != h.paintingColor) return false;
        }
        return true;
    }

    private void DisableAllTriggers()
    {
        foreach (var h in hallways)
        {
            if (h != null) h.disableTrigger();
        }
    }

    void generateSecondPuzzle()
    {
        UnityEngine.Debug.Log("first puzzle completed!");
        hallway1Replacement.SetActive(true);
        hallway1.SetActive(false);
        wardrobe.SetActive(true);
    }

    void generateThirdPuzzle()
    {
        UnityEngine.Debug.Log("second puzzle completed!");
        hallway1Replacement.SetActive(false);
        hallway1.SetActive(true);
        wardrobe.SetActive(false);

        foreach(var stairs in hallwaysStairs)
        {
            stairs.SetActive(true);
        }
        key1.SetActive(true);
        key2.SetActive(true);
        UnityEngine.Debug.Log("set keys to active");
        door.SetActive(true);
        
    }
}
