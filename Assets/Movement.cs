using TMPro;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float speed = 4.317f;
    public float speedMultiplier = 30f;
    public float jumpForce = 1.2522f;
    private Rigidbody body;
    public Transform cam;
    private Collision collision;
    public Bounds contactBounds;
    public GameObject positionText;
    private TextMeshProUGUI textMesh;

    public float x1 = 0f;
    public float z1 = 0f;
    public float x2 = 0f;
    public float z2 = 0f;

    private bool isGrounded;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        textMesh = positionText.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            body.MovePosition(body.position + new Vector3(0, jumpForce, 0));
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            speedMultiplier *= 1.3f;
        }
        else
        {
            speedMultiplier = 30f;
        }

        Vector3 direction = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 newRelativePosition = speedMultiplier * Time.deltaTime * speed * moveDir.normalized;

            body.MovePosition(newRelativePosition + body.position);
        }

        textMesh.text = body.position.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.collision = collision;

        if (collision.collider != null)
        {
            isGrounded = true;
        }
    }
}
