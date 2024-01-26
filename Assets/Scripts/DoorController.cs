using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        // Almacena la rotación inicial de la puerta
        initialRotation = transform.rotation;

        // Calcula la rotación de la puerta cuando está abierta
        targetRotation = initialRotation * Quaternion.Euler(0, 90, 0);
    }

    void Update()
    {
        // Gira la puerta hacia la posición de puerta abierta
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // Método para abrir la puerta
    public void OpenDoor()
    {
        targetRotation = Quaternion.Euler(0, 90, 0);
        Debug.Log("Puerta abierta");
    }

    // Método para cerrar la puerta
    public void CloseDoor()
    {
        targetRotation = initialRotation;
        Debug.Log("Puerta cerrada");
    }
}