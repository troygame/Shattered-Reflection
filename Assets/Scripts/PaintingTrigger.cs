using UnityEngine;
using UnityEngine.Events;

public class PaintingTrigger : MonoBehaviour
{
    [SerializeField] GameObject Hallway;

    void OnTriggerStay2D(Collider2D other){
        if(Input.GetKeyDown(KeyCode.F)){
            Hallway.GetComponent<PaintingInteraction>().setPainting(false, "blue");
        }
    } 
   
}
