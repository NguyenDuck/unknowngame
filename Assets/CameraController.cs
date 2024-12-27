using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private readonly float fixedCameraSenScale = Mathf.PI;
    public GameObject player;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * fixedCameraSenScale;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * fixedCameraSenScale;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        transform.position = player.transform.position + new Vector3(0, 1.6f / 2, 0);
    }
}
