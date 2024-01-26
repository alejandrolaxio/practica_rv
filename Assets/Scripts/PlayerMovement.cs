using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false; // Desactivar la gravedad del Rigidbody
    }

    void Update()
    {
        Vector2 input = new Vector2(
            Keyboard.current.dKey.isPressed ? 1 : (Keyboard.current.aKey.isPressed ? -1 : 0),
            Keyboard.current.wKey.isPressed ? 1 : (Keyboard.current.sKey.isPressed ? -1 : 0)
        );

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        Vector3 movement = (cameraForward.normalized * input.y + cameraRight.normalized * input.x).normalized * speed;

        // Suavizar el movimiento lateral
        Vector3 smoothMovement = Vector3.Lerp(rb.velocity, movement * speed, 0.1f);
        rb.velocity = smoothMovement;

        // Saltar si el jugador está en el suelo y presiona la tecla de espacio
        if (isGrounded && Keyboard.current.spaceKey.isPressed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Detectar si el jugador está en el suelo
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            DoorController door = other.GetComponent<DoorController>();
            if (door != null)
            {
                door.OpenDoor();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            DoorController door = other.GetComponent<DoorController>();
            if (door != null)
            {
                door.CloseDoor();
            }
        }
    }
}