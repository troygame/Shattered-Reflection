using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    public bool showUI = false;

    public GameObject fText;
    public HallwayPaintingInteraction.Colors ownColor;

    public void Start()
    {
        //showUI = true;

    }

    public void Update()
    {
        // Enables the 'F UI'
        fText.SetActive(showUI);
    }
}
