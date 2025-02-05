using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 2f;


    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the gun back and forth
        float newX = startPosition.x + Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
        transform.position = new Vector3(newX, startPosition.y, startPosition.z);
    }
}