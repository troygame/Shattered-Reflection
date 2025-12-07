using UnityEngine;
using System;
public class PaintingInteraction : MonoBehaviour
{
    [SerializeField] bool hasPainting;
    [SerializeField] string colorPainting;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform player;

    private GameObject ownPainting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(hasPainting){
            GameObject ownPainting = Instantiate(
            prefab,
            new Vector2(0, 5),
            Quaternion.identity,
            transform
            ); 
            ownPainting.name = colorPainting;
            ownPainting.transform.localScale = new Vector2(0.15f, 0.2f);
        }
        else{
            //
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void setPainting(bool paintingStatus, string color){
        hasPainting = paintingStatus;
        colorPainting = color;
    }
}
