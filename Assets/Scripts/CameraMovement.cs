using System.Numerics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] UnityEngine.Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position=player.position+offset;
    }
}
