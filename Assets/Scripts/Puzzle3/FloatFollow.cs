using System.Diagnostics;
using UnityEngine;

public class FloatFollow : MonoBehaviour
{
    [Header("State")]
    public bool followingPlayer = false;

    [Header("Auto-follow trigger")]
    [SerializeField] Transform target; // set when player enters trigger

    [Header("Follow")]
    [SerializeField] Vector3 localOffset = new Vector3(0.6f, 1.2f, 0f);
    [SerializeField] float followSmoothTime = 0.15f;   // smaller = tighter follow

    [Header("Float Motion")]
    [SerializeField] float bobAmplitude = 0.12f;
    [SerializeField] float bobFrequency = 1.6f;

    [SerializeField] float swayAmplitude = 0.10f;
    [SerializeField] float swayFrequency = 1.1f;

    [Header("Optional: random flutter")]
    [SerializeField] float jitterAmplitude = 0.03f;
    [SerializeField]public float jitterFrequency = 3.0f;

    [SerializeField] FloatFollow otherPart;

    [SerializeField] GameObject completeKey;

    private Vector3 velocity;
    private Vector3 noiseSeed;

    void Awake()
    {
        noiseSeed = new Vector3(Random.value * 10f, Random.value * 10f, Random.value * 10f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (followingPlayer) return;

        if (other!=null && other.CompareTag("Player"))
        {
            if (otherPart.followingPlayer)
            {
                completeKey.SetActive(true);
                otherPart.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
            target = other.transform;
            followingPlayer = true;
        }
    }

    void LateUpdate()
    {
        if (!followingPlayer || !target) return;

        Vector3 basePos = target.TransformPoint(localOffset);

        float t = Time.time;

        float bob = Mathf.Sin(t * bobFrequency * Mathf.PI * 2f) * bobAmplitude;
        float sway = Mathf.Sin(t * swayFrequency * Mathf.PI * 2f + 1.3f) * swayAmplitude;

        float nx = (Mathf.PerlinNoise(noiseSeed.x, t * jitterFrequency) - 0.5f) * 2f;
        float ny = (Mathf.PerlinNoise(noiseSeed.y, t * jitterFrequency) - 0.5f) * 2f;

        Vector3 floatOffset =
            new Vector3(sway, bob, 0f) +
            new Vector3(nx, ny, 0f) * jitterAmplitude;

        Vector3 desired = basePos + floatOffset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desired,
            ref velocity,
            followSmoothTime
        );
    }
}
