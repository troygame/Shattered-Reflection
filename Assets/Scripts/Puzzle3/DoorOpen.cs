using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject playerKey;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(playerKey.activeSelf && other.transform.CompareTag("Player")){
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
}
