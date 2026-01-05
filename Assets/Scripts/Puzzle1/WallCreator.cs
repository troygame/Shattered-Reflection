using UnityEngine;

public class WallCreator : MonoBehaviour
{
    
    [SerializeField] HallwayPaintingInteraction hallway;
    [SerializeField] GameObject wall;
    //public bool wallStatus = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hallway.hasPainting){
            wall.SetActive(false);
        }
        else{
            wall.SetActive(true);
        }
        //Debug.Log(painting.ownColor);
    }
}
