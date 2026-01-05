using UnityEngine;
using System;
public class HallwayPaintingInteraction : MonoBehaviour
{
    public bool hasPainting;
    //[SerializeField] string colorPainting;
    //[SerializeField] GameObject prefabPainting;
    public enum Colors
    {
        red,
        orange,
        yellow,
        green,
        blue,
        indigo,
        violet
    }
    [SerializeField] Transform paintingPosition;
    public Colors hallwayColor;
    //[SerializeField] Transform player;
    [SerializeField] GameObject trigger;

    [SerializeField] GameObject trigger2;

    public Colors paintingColor;
    public PaintingManager painting;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*if(hasPainting){
            ownPainting = Instantiate(
            prefabPainting,
            new Vector2(0, 5),
            Quaternion.identity,
            transform
            ); 
            ownPainting.name = colorPainting;
            ownPainting.transform.localScale = new Vector2(0.15f, 0.2f);
        }
        else{
            ownPainting = null;
        }
        */
    }


    public void disableTrigger()
    {
        trigger.SetActive(false);
        trigger2.SetActive(false);
    }

    public void setPainting(PaintingManager p){
        hasPainting=true;
        painting=p;
        paintingColor=p.ownColor;
        int holderLayer = LayerMask.NameToLayer("Painting");
        painting.gameObject.layer = holderLayer;  
        painting.gameObject.transform.position=paintingPosition.position;
    }

    public void removePainting()
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        painting.gameObject.layer = groundLayer;  
        painting.showUI = false; 
        hasPainting=false;
        painting=null;
        
    }


}
