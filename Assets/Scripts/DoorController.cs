using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        // Almacena la rotaci�n inicial de la puerta
        initialRotation = transform.rotation;

        // Calcula la rotaci�n de la puerta cuando est� abierta
        targetRotation = initialRotation * Quaternion.Euler(0, 90, 0);
    }

    void Update()
    {
        // Gira la puerta hacia la posici�n de puerta abierta
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // M�todo para abrir la puerta
    public void OpenDoor()
    {
        targetRotation = Quaternion.Euler(0, 90, 0);
        Debug.Log("Puerta abierta");
    }

    // M�todo para cerrar la puerta
    public void CloseDoor()
    {
        targetRotation = initialRotation;
        Debug.Log("Puerta cerrada");
    }
}