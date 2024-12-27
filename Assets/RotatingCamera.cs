using UnityEngine;

public class RotatingCamera : MonoBehaviour
{

    public float speed = 1.2f;
    public Vector3 direction = Vector3.right;
    public Quaternion rotation;

    void Start()
    {
    }

    void Update()
    {
        rotation = transform.rotation * Quaternion.LookRotation(direction);
        float degDelta = speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, degDelta);
    }
}
