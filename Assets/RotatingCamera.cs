using UnityEngine;

public class RotatingCamera : MonoBehaviour
{

    public float speed = 1f;
    public Vector3 direction = Vector3.right;

    void Start()
    {
    }

    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
