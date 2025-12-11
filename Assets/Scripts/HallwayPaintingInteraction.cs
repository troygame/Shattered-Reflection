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
        violet,
        blue,
        purple
    }
    [SerializeField] Transform paintingPosition;
    [SerializeField] Colors hallwayColor;
    //[SerializeField] Transform player;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject PaintingHolder;

    Colors paintingColor;
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

    public void setPainting(PaintingManager p){
        hasPainting=true;
        painting=p;
        paintingColor=p.ownColor;
        PaintingHolder.SetActive(true);
        painting.gameObject.transform.position=paintingPosition.position;
    }

    public void removePainting()
    {
        hasPainting=false;
        painting=null;
        PaintingHolder.SetActive(false);
    }
}
