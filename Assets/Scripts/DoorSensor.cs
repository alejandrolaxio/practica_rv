using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    public DoorController doorController; // Asigna el objeto de la puerta desde el Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.OpenDoor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.CloseDoor();
        }
    }
}
