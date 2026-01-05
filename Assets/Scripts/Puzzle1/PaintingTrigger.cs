using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class PaintingTrigger : MonoBehaviour
{
    [SerializeField] HallwayPaintingInteraction hallway;
    private Collider2D collider;

    [SerializeField] GameObject wardrobe;

    void Update(){

        if (collider != null)
        {

            if (hallway.hasPainting)
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    //UnityEngine.Debug.Log("removedPainting");
                    hallway.removePainting();
                }
            }
            else if (collider.CompareTag("Painting"))
            {
                //UnityEngine.Debug.Log("painting Touching");
                if (Input.GetKeyDown(KeyCode.F))
                {

                    hallway.setPainting(collider.GetComponent<PaintingManager>());
                }

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //UnityEngine.Debug.Log("enter");
        collider = other;

        if (other.CompareTag("Player") && hallway.hasPainting)
        {
            hallway.painting.showUI = true;
        }
        else if (other.CompareTag("Painting"))
        {
            other.GetComponent<PaintingManager>().showUI = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        collider = null;

        if (other.CompareTag("Player") && hallway.hasPainting)
        {
            hallway.painting.showUI = false;
        }
        else if (other.CompareTag("Painting"))
        {
            other.GetComponent<PaintingManager>().showUI = false;
        }
    }
   
}
