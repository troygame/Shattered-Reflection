using UnityEngine;
using System;
public class PaintingInteraction : MonoBehaviour
{
    [SerializeField] bool hasPainting;
    [SerializeField] string colorPainting;
    [SerializeField] GameObject prefabPainting;
    [SerializeField] Transform player;


    private GameObject ownPainting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(hasPainting){
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
    }

    public void setPainting(bool paintingStatus, string color){
        hasPainting = paintingStatus;
        colorPainting = color;
    }
}
