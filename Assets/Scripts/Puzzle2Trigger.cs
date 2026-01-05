using UnityEngine;

public class Puzzle2Trigger : MonoBehaviour
{
    public bool touchedWardRobe=false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wardrobe"))
        {
            touchedWardRobe=true;
        }
    }

}
