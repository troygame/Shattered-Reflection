using UnityEngine;
using UnityEngine.Events;

public class PaintingTrigger : MonoBehaviour
{
    [SerializeField] HallwayPaintingInteraction hallway;

    void OnTriggerStay2D(Collider2D other){

        if (hallway.hasPainting)
        {
            
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("removedPainting");
                hallway.removePainting();
            }
        }
        else if (other.CompareTag("Painting"))
        {
            Debug.Log("painting Touching");
            if (Input.GetKey(KeyCode.F))
            {
                
                hallway.setPainting(other.GetComponent<PaintingManager>());
            }
            
        }
        
    }


   
}
